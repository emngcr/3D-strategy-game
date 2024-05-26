using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

[System.Serializable]
public enum Mission
{
    KillEnemy,
    GoToPoint1,
    GoToPoint2,
    DestroyBase,
    Fork,
    MoveNKill,
    MoveToBase,
    MoveNKillSec,
    Finito
}
public class Quest : MonoBehaviour , IPunObservable
{
    public Mission theMission;
    public Transform questPos1;
    public Transform questPos2;
    public Transform questPos3;
    public Transform questPos4;
    public Transform MissionLeftSide;
    public Transform MissionLeftSideMove1;
    public Transform MissionLeftSideMove2;
    public Transform forkTransform;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform FinitoH;


    private int i;
    private int j;
    private int k;

    //public Transform MissionMarkerPos;

    public TextMeshProUGUI quest1Text;
    //public TextMeshProUGUI quest2Text;
    
    public float questRange = 10;
    public Transform player;

    public GameObject MissionMarker;
    public PlayerManager playerMan;

   

    void Start()
    {
        player = playerMan.commando.transform;
    }

    // Update is called once per frame
    void Update()
    {

       
       GetComponent<PhotonView>().RPC("Mqst", RpcTarget.All);
         
      
    }

    [PunRPC]
    public void Mqst()
    {

        switch (theMission)
        {
            case Mission.GoToPoint1:
                quest1Text.text = "Belirtilen Bölgeye Ýntikal Et ";

                MissionMarker.transform.position = questPos1.position;

                if (Vector3.Distance(player.position, questPos1.position) < questRange)
                {


                    while (i < 4)
                    {
                        PhotonNetwork.Instantiate("dusmanV2", spawn1.transform.position, Quaternion.identity);
                        i++;
                    }




                    Debug.Log("Congratulations , You done Quest 1");
                    theMission = Mission.KillEnemy;
                }
                break;
            case Mission.GoToPoint2:
                quest1Text.text = "Düþman inine yaklaþmak için belirtilen noktaya git";
                MissionMarker.transform.position = questPos2.position;
                MissionMarker.SetActive(true);
                if (Vector3.Distance(player.position, questPos2.position) < questRange)
                {

                    Debug.Log("Congratulations twice , You done Quest 2");
                    theMission = Mission.DestroyBase;
                }
                break;
            case Mission.DestroyBase:
                quest1Text.text = "Havan topu Ya da El bombasý kullanarak kampý temizle";
                MissionMarker.SetActive(false);

                if (GameObject.FindGameObjectWithTag("enemyBase").GetComponent<enemyspawnbaseStat>().currentHealth <= 0)
                {
                    Debug.Log("Well done , You destroy the enemy base");
                    quest1Text.text = "Bir bölgeyi temizledin Ýyi iþ";
                    theMission = Mission.Fork;


                    while (i < 3)
                    {
                        PhotonNetwork.Instantiate("dusmanV2", MissionLeftSide.transform.position, Quaternion.identity);
                        i++;
                    }




                }
                break;
            case Mission.KillEnemy:
                quest1Text.text = "Karþýna Çýkan düþmanlarý etkisiz hale getir";
                MissionMarker.SetActive(false);

                if (GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyStats>().currentHealth <= 0)
                {
                    Debug.Log("Your awesome Kill Three enemy");

                    theMission = Mission.GoToPoint2;

                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanV2", spawn2.transform.position, Quaternion.identity);
                        PhotonNetwork.Instantiate("dusmanV2", spawn3.transform.position, Quaternion.identity);
                        k++;
                    }
                   
                }
              
                break;
            case Mission.Fork:
                quest1Text.text = "Ýlerlemeye devam et                  ";
                MissionMarker.SetActive(true);
                MissionMarker.transform.position = forkTransform.position;
                if (Vector3.Distance(player.position, questPos3.position) < questRange)
                {

                    theMission = Mission.MoveNKill;
                    Debug.Log("You chose the Left Side");
                    quest1Text.text = "Yoldaki Düþmalari Temizle";
                    MissionMarker.SetActive(false);
                }
                if (Vector3.Distance(player.position, questPos4.position) < questRange)
                {
                    theMission = Mission.MoveToBase;
                    Debug.Log("You chose the Right Side");
                    quest1Text.text = "Düþman üssünü bul ve bombala";
                    MissionMarker.SetActive(false);
                }
                break;
            case Mission.MoveNKill:
                GameObject.FindGameObjectWithTag("Player").GetComponent<Skills>().bombaSayisi += 5;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Skills>().bandajSayisi += 3;


                Debug.Log("Mountain climbing one comp");


                while (i < 3)
                {
                    PhotonNetwork.Instantiate("dusmanV2", MissionLeftSideMove1.transform.position, Quaternion.identity);
                    i++;
                }
                



                theMission = Mission.MoveNKillSec;
                break;
            case Mission.MoveNKillSec:
                quest1Text.text = "Tepeye Ulaþ   ve Yoldaki Düþmanlarý Ýmha et";
                Debug.Log("Mountain climbing one comp 2");


                while (j < 3)
                {
                    PhotonNetwork.Instantiate("dusmanV2", MissionLeftSideMove2.transform.position, Quaternion.identity);
                    j++;
                }
                theMission = Mission.Finito;
                break;
            case Mission.Finito:
                MissionMarker.SetActive(true);
                MissionMarker.transform.position = FinitoH.position;
                if (Vector3.Distance(player.position, FinitoH.position) < questRange)
                {
                    PhotonNetwork.LoadLevel("scene 2");
                }
                    break;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(theMission);
            
            
        }
        else if (stream.IsReading)
        {
            theMission= (Mission)stream.ReceiveNext();
            
            
        }
    }
}
