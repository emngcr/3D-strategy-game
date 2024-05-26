using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;



public class PlayerManager3 : MonoBehaviour
{
    #region Singleton

    public static PlayerManager3 instance;

    void Awake()
    {
        instance = this;
        SpawnPlayer();
    }

    #endregion

    public GameObject commando;



    public void SpawnPlayer()
    {

        commando = PhotonNetwork.Instantiate("KommandoV2", new Vector3(-1509, -308, -533), Quaternion.identity);
        // print(commando);



    }

    public void Killplayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
