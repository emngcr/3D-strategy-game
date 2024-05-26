using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{

    public GameObject exploEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
        
    }

    void Explode()
    {
        Instantiate(exploEffect, transform.position, transform.rotation);
        /*Collider[] colliders =  Physics.OverlapSphere(transform.position, radius);
         foreach(Collider nearbyObj in colliders)
         {
             Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();

             if(rb != null)
             {
                 rb.AddExplosionForce(force, transform.position, radius);
             }
         }*/
        
    }
 
    
}
