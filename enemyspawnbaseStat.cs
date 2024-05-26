using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class enemyspawnbaseStat : CharacterStats
{
    
   [PunRPC]
    public override void Die()
    {
        base.Die();

       

       // Destroy(gameObject);
    }
}
