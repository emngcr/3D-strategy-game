using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class EnemyStats : CharacterStats
{
    private Animator death;
    public void Start()
    {
        death = GetComponent<Animator>();
    }
    [PunRPC]
    public override void Die()
    {
        base.Die();

        death.SetBool("death",true);
        //ölüm animasyonu

       // Destroy(gameObject);
    }
}
