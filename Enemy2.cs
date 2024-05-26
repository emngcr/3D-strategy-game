using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class Enemy2 : Interactable
{
    CharacterStats myStats2;
    PlayerManager2 playermanager2;
    void Start()
    {
        playermanager2 = PlayerManager2.instance;
        myStats2 = GetComponent<CharacterStats>();
    }
    public override void Interacted()
    {
        base.Interacted();
        // dusmana saldir

        Debug.Log("4");
        Combat playerCombat = playermanager2.commando.GetComponent<Combat>();
        if (playerCombat != null)
        {
            Debug.Log("5");
            playerCombat.Attack(myStats2);
        }

    }
}
