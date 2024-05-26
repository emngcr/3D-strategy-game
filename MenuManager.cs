using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject userNameScreen, ConnectScreen;

    [SerializeField]
    private GameObject CreateUserNameButton;

    [SerializeField]
    private InputField UserNameInput, CreateRoomInput, JoinRoomInput;

    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to lobby");
        userNameScreen.SetActive(true);
    }
    public override void OnJoinedRoom()
    {
        // play game scene
        PhotonNetwork.LoadLevel("scene 2");
    }
    #region UIMethods

    public void Onclick_CreateNameBtn()
    {
       
        PhotonNetwork.NickName = UserNameInput.text;
        userNameScreen.SetActive(false);
        ConnectScreen.SetActive(true);
    }

    public void NameFieldChanged()
    {
        if (UserNameInput.text.Length > 2)
        {
            CreateUserNameButton.SetActive(true);

        }
        else
        {
            CreateUserNameButton.SetActive(false);
        }
    }

    public void onClick_JoinRoom()
    {
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(JoinRoomInput.text,ro,TypedLobby.Default);
    }
    public void onClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateRoomInput.text, new RoomOptions { MaxPlayers = 2 }, null);
         
    }
    #endregion


}
