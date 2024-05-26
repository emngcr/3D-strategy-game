using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemySpawnPointInt : Interactable
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


        Combat playerCombat = playermanager.commando.GetComponent<Combat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }

    }
}
