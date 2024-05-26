using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SingleOrManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject SingleInput, MultiInput;

 

    public void SingleButton()
    {
        PhotonNetwork.OfflineMode = true;
        PhotonNetwork.JoinRoom(null);
    }
    public void MultiButton()
    {
        
        PhotonNetwork.LoadLevel("lobby");
    }
    public override void OnJoinedRoom()
    {
        // play game scene
        PhotonNetwork.LoadLevel("scene 2");
    }
}
