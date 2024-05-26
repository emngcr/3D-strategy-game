using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    CharacterStats myStats;
    PlayerManager playermanager;
     void Start()
    {
        playermanager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }
    public override void Interacted()
    {
        base.Interacted();
        // dusmana saldir

        Debug.Log("5");
        Combat playerCombat = playermanager.commando.GetComponent<Combat>();
        if (playerCombat != null)
        {
            Debug.Log("6");
            playerCombat.Attack(myStats);
        }

    }
}
