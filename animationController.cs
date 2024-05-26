using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animationController : MonoBehaviour
{
    public AudioClip g3_voice;
    const float smoothTime = .1f;
    private NavMeshAgent asker;
    private Animator asker_kos;
    private Combat combat;
    private float speed;
    private bool comelme;
    public AudioClip step_sound;
   

    void Start()
    {
        asker = GetComponent<NavMeshAgent>();
        asker_kos = GetComponent<Animator>();
        combat = GetComponent<Combat>();

    }

    
    void Update()
    {

        speed = asker.velocity.magnitude;
        asker_kos.SetFloat("speed", speed);
        asker_kos.SetBool("atesleme", combat.firing);

        asker_kos.SetBool("comelme", comelme);
        asker_kos.SetBool("comelerek_ates", combat.firing);
     


        if (Input.GetKeyDown(KeyCode.C))
        {
            comelme = !comelme;

            if(comelme == true)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().size /= 2;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>().size *= 2;
            }
        
        }

     

    }
    public void g3_shooting()
    {
        GetComponent<AudioSource>().PlayOneShot(g3_voice);
    }
    public void step_sound_func()
    {
        GetComponent<AudioSource>().PlayOneShot(step_sound);
    }
}
