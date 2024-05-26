using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform target;
    Combat combat;
    NavMeshAgent terrorist;


    public float lookRadius = 10f;
    void Start()
    {
        target = PlayerManager.instance.commando.transform;
        terrorist = GetComponent<NavMeshAgent>();
        combat = GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerisNotAttacking();



    }
   /* void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }*/
    void FaceTarget()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    /*   void isAttacking()
       {

            if (terrorist.GetComponent<EnemyStats>().hashurt)
                terrorist.SetDestination(target.position);

           if (terrorist.GetComponent<EnemyStats>().currentHealth<100)
           {
               terrorist.SetDestination(target.position);
           }

       }*/

    void PlayerisNotAttacking()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        /* Vector3 targetDir = target.position - transform.position;
         angle = Vector3.Angle(targetDir, transform.forward);*/

        if (distance <= lookRadius /*&& distance<=angle*/)
        {
            terrorist.stoppingDistance = 14;
            terrorist.SetDestination(target.position);

            if (distance <= terrorist.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }

                FaceTarget();
            }

        }
        else
        {
            terrorist.stoppingDistance = 2;
        }
        if (distance >= lookRadius)// if player hit you go to player
        {
            if (terrorist.GetComponent<EnemyStats>().currentHealth < 100)
            {
                terrorist.SetDestination(target.position);

            }

        }

    }


    /* IEnumerator lookLikeEnemy()
     {
         yield return new WaitForSeconds(10); 
     }*/

}
