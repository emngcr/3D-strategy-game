using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;



public class PlayerManager2 : MonoBehaviour
{
    #region Singleton

    public static PlayerManager2 instance;

    void Awake()
    {
        instance = this;
        SpawnPlayer();
    }

    #endregion

    public GameObject commando;



    public void SpawnPlayer()
    {

        commando = PhotonNetwork.Instantiate("KommandoV2", new Vector3(-1823, -343, -445), Quaternion.identity);
        // print(commando);



    }

    public void Killplayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
