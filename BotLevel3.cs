using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class BotLevel3 : MonoBehaviour
{

    Camera cam;
    Transform target;
    Combat combat;
    NavMeshAgent terrorist;
    public float lookRadius = 10f;
    private bool isDead;



    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager3.instance.commando.transform;
        terrorist = GetComponent<NavMeshAgent>();
        combat = GetComponent<Combat>();


    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().currentHealth > 0 && GetComponent<EnemyStats>().currentHealth > 0)
        {
            enemyAttack();
            //GetComponent<PhotonView>().RPC("enemyAttack", RpcTarget.All);
        }
        else
        {
            terrorist.SetDestination(transform.position);
        }


    }


    void enemyAttack()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), ((target.position + new Vector3(0, 1, 0)) - (transform.position + new Vector3(0, 1, 0))), out hit, Mathf.Infinity))
        {
            Debug.Log(hit.collider.name);

            if (hit.transform.CompareTag("Player"))
            {

                Debug.DrawRay(transform.position + new Vector3(0, 1, 0), ((target.position + new Vector3(0, 1, 0)) - (transform.position + new Vector3(0, 1, 0))) * hit.distance, Color.yellow);



                if (distance <= lookRadius)
                {
                    terrorist.stoppingDistance = 34;
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
            else
            {
                Debug.DrawRay(transform.position, ((target.position + new Vector3(0, 1, 0)) - (transform.position)) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    void FaceTarget()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
