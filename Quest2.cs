using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

[System.Serializable]
public enum Mission2
{
   AroundTrap,
   AroundTrap2,
   AroundTrap3,
   WeirdCircle,
   GoAhead
}
public class Quest2 : MonoBehaviour , IPunObservable
{
    public Mission2 theMission2;
    public Transform questPos1;
    public Transform questPos2;
    public Transform questPos3;
    public Transform questPos4;
    //public Transform questPos4;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;


    private int i = 0;
    private int j = 0;
    private int k = 0;
    //public Transform MissionMarkerPos;

    public TextMeshProUGUI QuestText;
    //public TextMeshProUGUI quest2Text;

    public float questRange = 20f;
    public Transform player;

    public GameObject MissionMarker;
    public PlayerManager2 playerMan;



    void Start()
    {
        player = playerMan.commando.transform;
    }

    // Update is called once per frame
    void Update()
    {


        GetComponent<PhotonView>().RPC("Mqst2", RpcTarget.AllBuffered);


    }

    [PunRPC]
    public void Mqst2()
    {
        Debug.Log("1");
        switch (theMission2)
        {
            
            case Mission2.AroundTrap:
                Debug.Log("2");
                QuestText.text = "Pusulardan kurtul ve cephenin sonuna ulaþ!";
                if (Vector3.Distance(player.position, questPos1.position) < questRange)
                {
                    

                    Debug.Log("3");
                    while (i < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel2", spawn1.transform.position, Quaternion.identity);
                        i++;
                    }
                    i = 0;
                    while (i < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel2", spawn2.transform.position, Quaternion.identity);
                        i++;
                    }
                    Debug.Log("Congratulations , You done Quest 1");
                    theMission2 = Mission2.AroundTrap2;
                }
                    break;
            case Mission2.AroundTrap2:
                QuestText.text = "Ýlerlemeye devam et yaklaþtýn";
                if (Vector3.Distance(player.position, questPos2.position) < questRange)
                {
                    while (j < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel2", spawn3.transform.position, Quaternion.identity);
                        j++;
                    }
                    j = 0;
                    while (j < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel2", spawn4.transform.position, Quaternion.identity);
                        j++;
                    }
                    Debug.Log("Congratulations , You done Quest 2");
                    theMission2 = Mission2.AroundTrap3;
                }
                    break;
            case Mission2.AroundTrap3:
                QuestText.text = "Taþlarýn arkasýna Dikkat et";
                if (Vector3.Distance(player.position, questPos3.position) < questRange)
                {
                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel2", spawn5.transform.position, Quaternion.identity);
                        k++;
                    }
                    k = 0;
                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel2", spawn6.transform.position, Quaternion.identity);
                        k++;
                    }
                }
                Debug.Log("Congratulations , You done Quest 3");
                theMission2 = Mission2.GoAhead;
                break;
            case Mission2.GoAhead:
                QuestText.text = "Düþman Kampýna Gitmek için verilen noktaya git!";
                MissionMarker.transform.position = questPos4.position;
                if (Vector3.Distance(player.position, questPos4.position) < questRange)
                    PhotonNetwork.LoadLevel("scene 3");
                break;

        }


    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(theMission2);


        }
        else if (stream.IsReading)
        {
            theMission2 = (Mission2)stream.ReceiveNext();


        }
    }
}

   
    

