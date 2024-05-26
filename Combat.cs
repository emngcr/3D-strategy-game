using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(CharacterStats))]
public class Combat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCoolDown = 0f;
    public float attackDelay = .6f;
    public bool firing;
   

    public event System.Action OnAttack;

    CharacterStats myStats;
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }
     void Update()
    {
        attackCoolDown -= Time.deltaTime;
    }
    public void Attack(CharacterStats targetStats)
    {
        if(attackCoolDown <= 0f)
        {
            StartCoroutine(doDamage(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCoolDown = 1f / attackSpeed;

            firing = true;
           
        }
       
    }
    IEnumerator doDamage (CharacterStats stat, float delay)
    {
        yield return new WaitForSeconds(delay);
        stat.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, myStats.damage.GetValue());
        //stat.TakeDamage(myStats.damage.GetValue());
        firing = false;
        
    }
}
