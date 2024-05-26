using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public enum Mission3
{
    WhataMaze,
    WhataMaze2,
    WhataMaze3,
    WhataMaze4,
    GoodByHell,
    WelcomeWedding
}
public class Quest3 : MonoBehaviour ,IPunObservable
{
    public Mission3 theMission3;
    public Transform questPos1;
    public Transform questPos2;
    public Transform questPos3;
    public Transform questPos4;
    public Transform questPos5;
    public Transform questPos6;
    //public Transform questPos4;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;
    public Transform spawn9;


    private int i = 0;
    private int j = 0;
    private int k = 0;
    //public Transform MissionMarkerPos;

    public TextMeshProUGUI QuestText;
    //public TextMeshProUGUI quest2Text;

    public float questRange = 20f;
    public float qRange=5f;
    public Transform player;

     public GameObject MissionMarker;
    public PlayerManager3 playerMan;



    void Start()
    {
        player = playerMan.commando.transform;
    }

    // Update is called once per frame
    void Update()
    {


        GetComponent<PhotonView>().RPC("Mqst3", RpcTarget.AllBuffered);


    }

    [PunRPC]
    public void Mqst3()
    {
        Debug.Log("1");
        switch (theMission3)
        {

            case Mission3.WhataMaze:
                Debug.Log("2");
                MissionMarker.SetActive(true);
                MissionMarker.transform.position = questPos1.position;
                if (Vector3.Distance(player.position, questPos1.position) < questRange)
                {
                    QuestText.text = "Burasý bir labirente benziyor dikkat et ve arkada düþman býrakma";
                    Debug.Log("3");
                    while (i < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel3", spawn1.transform.position, Quaternion.identity);
                        i++;
                    }
                    i = 0;
                    while (i < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel3", spawn2.transform.position, Quaternion.identity);
                        i++;
                    }
                    Debug.Log("Congratulations , You done Quest 1");
                    theMission3 = Mission3.WhataMaze2;
                }
                break;
            case Mission3.WhataMaze2:
                MissionMarker.transform.position = questPos2.position;
                
                if (Vector3.Distance(player.position, questPos2.position) < questRange)
                {
                    while (j < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel3", spawn3.transform.position, Quaternion.identity);
                        j++;
                    }
                    j = 0;
                    while (j < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel3", spawn4.transform.position, Quaternion.identity);
                        j++;
                    }
                    Debug.Log("Congratulations , You done Quest 2");
                    theMission3 = Mission3.WhataMaze3;
                }
                break;
            case Mission3.WhataMaze3:
                MissionMarker.transform.position = questPos3.position;
                QuestText.text = "Labirenti bitiridin tebrikler artýk yola çýkma vakti ilerle";
                if (Vector3.Distance(player.position, questPos3.position) < questRange)
                {
                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel3", spawn5.transform.position, Quaternion.identity);
                        k++;
                    }
                   
                }
                Debug.Log("Congratulations , You done Quest 3");
                MissionMarker.SetActive(false);
                theMission3 = Mission3.GoodByHell;
                break;
            case Mission3.GoodByHell:
                QuestText.text = " ";
                if (Vector3.Distance(player.position, questPos4.position) < qRange)
                {
                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel3", spawn7.transform.position, Quaternion.identity);
                        k++;
                    }
                    k = 0;
                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel3", spawn6.transform.position, Quaternion.identity);
                        k++;
                    }
                }
                if (Vector3.Distance(player.position, questPos5.position) < qRange)
                {
                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel3", spawn8.transform.position, Quaternion.identity);
                        k++;
                    }
                    k = 0;
                    while (k < 2)
                    {
                        PhotonNetwork.Instantiate("dusmanLevel3", spawn9.transform.position, Quaternion.identity);
                        k++;
                    }
                }
                theMission3 = Mission3.WelcomeWedding;
                break;
            case Mission3.WelcomeWedding:
                
                MissionMarker.transform.position = questPos6.position;
                if (Vector3.Distance(player.position, questPos6.position) < questRange)
                    PhotonNetwork.LoadLevel("scene 4");
                break;

        }


    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(theMission3);


        }
        else if (stream.IsReading)
        {
            theMission3 = (Mission3)stream.ReceiveNext();


        }
    }
}




