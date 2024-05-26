using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public enum Mission4
{
    WhereIsTheBoss,
    WhereIsTheBoss2,
    WhereIsTheBoss3,
    WhoIsTheBoss,
    Complete,
    Conq
}
public class Quest4 : MonoBehaviour , IPunObservable
{
    public Mission4 theMission4;
    public Transform questPos1;
    public Transform questPos2;
    public Transform questPos3;
    public Transform questPos4;
    //public Transform questPos5;

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;


    private int i = 0;
    private int j = 0;
    private int k = 0;
    private int n = 0;
    //public Transform MissionMarkerPos;

    public TextMeshProUGUI QuestText;
    //public TextMeshProUGUI quest2Text;

    public float questRange = 20f;
    public float qRange = 5f;
    public Transform player;

    public GameObject MissionMarker;
    public PlayerManager4 playerMan;



    void Start()
    {
        player = playerMan.commando.transform;
    }

    // Update is called once per frame
    void Update()
    {


        GetComponent<PhotonView>().RPC("Mqst4", RpcTarget.AllBuffered);


    }

    [PunRPC]
    public void Mqst4()
    {
        Debug.Log("1");
        switch (theMission4)
        {

            case Mission4.WhereIsTheBoss:
                MissionMarker.SetActive(true);
                MissionMarker.transform.position = questPos1.position;
                Debug.Log("2");
                if (Vector3.Distance(player.position, questPos1.position) < questRange)
                {
                    QuestText.text = "Düþmanýn baþý buralarda bir yerlerde olmalý onu bul ve yok et!";
                    Debug.Log("3");
                    while (i < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel4", spawn1.transform.position, Quaternion.identity);
                        i++;
                    }
                    i = 0;
                    while (i < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel4", spawn2.transform.position, Quaternion.identity);
                        i++;
                    }
                    Debug.Log("Congratulations , You done Quest 1");
                    theMission4 = Mission4.WhereIsTheBoss2;
                }
                break;
            case Mission4.WhereIsTheBoss2:
                MissionMarker.transform.position = questPos2.position;
                if (Vector3.Distance(player.position, questPos2.position) < questRange)
                {
                    while (j < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel4", spawn3.transform.position, Quaternion.identity);
                        j++;
                    }
                    j = 0;
                    while (j < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel4", spawn4.transform.position, Quaternion.identity);
                        j++;
                    }
                    Debug.Log("Congratulations , You done Quest 2");
                    theMission4 = Mission4.WhereIsTheBoss3;
                }
                
                break;
            case Mission4.WhereIsTheBoss3:
                MissionMarker.transform.position = questPos3.position;
                if (Vector3.Distance(player.position, questPos3.position) < questRange)
                {
                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel4", spawn5.transform.position, Quaternion.identity);
                        k++;
                    }
                    k = 0;
                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel4", spawn6.transform.position, Quaternion.identity);
                        k++;
                    }
                    theMission4 = Mission4.WhoIsTheBoss;
                }
                Debug.Log("Congratulations , You done Quest 3");
                
                break;
            case Mission4.WhoIsTheBoss:
                MissionMarker.transform.position = questPos4.position;
                n = 0;
                if (Vector3.Distance(player.position, questPos4.position) < questRange)
                {
                    while (n < 1)
                    {
                        PhotonNetwork.Instantiate("dusmanLevelBoss", spawn7.transform.position, Quaternion.identity);
                        n++;
                    }
                    theMission4 = Mission4.Complete;
                }
                
                break;
            case Mission4.Complete:
                MissionMarker.SetActive(false);
                QuestText.text = "Düþmanlarý temizledin Tek baþlarý kaldý onu da yok et";
                if (GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyStats>().currentHealth <= 0)
                    QuestText.text = "Düþman Baþýný Bitir";
   
               break;
          
        }


    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(theMission4);


        }
        else if (stream.IsReading)
        {
            theMission4 = (Mission4)stream.ReceiveNext();


        }
    }
}




