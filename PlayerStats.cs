using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;
using Photon.Pun;

public class PlayerStats : CharacterStats
{
    public baris_ui healthBar;   
    private Animator olum;

    public TwoBoneIKConstraint handIK;
    public GameObject rifle;

    public void Start()
    {
        olum = GetComponent<Animator>();
        healthBar.SetMaxHealth(GetComponent<PlayerStats>().Health);
    }
    private void Update()
    {
        
            healthBar.SetHealth(GetComponent<PlayerStats>().currentHealth);
    }


    [PunRPC]
    public override void Die()
    {
        base.Die(); // ölür
        rifle.SetActive(false);
        handIK.weight = 0;
        olum.SetBool("can",true);
       // PhotonNetwork.Destroy(gameObject);
        //PlayerManager.instance.Killplayer();
    }
}
