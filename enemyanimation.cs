using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyanimation : MonoBehaviour
{
    public AudioClip ses;
    private NavMeshAgent enemy;
    private Animator enemy_movement;
    private Combat combat;
    float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemy_movement = GetComponent<Animator>();
        combat = GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = enemy.velocity.magnitude;
        enemy_movement.SetFloat("speed", speed);
        enemy_movement.SetBool("attack",combat.firing);

    }
    public void akm_sound_shooting()
    {
        GetComponent<AudioSource>().PlayOneShot(ses);
    }

}
