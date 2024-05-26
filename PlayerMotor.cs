using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour , IPunObservable
{
    Transform target;
    NavMeshAgent asker;
    void Start()
    {
        asker = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            asker.SetDestination(target.position);
            faceTarget();
        }
    }
    public void moveToPoint(Vector3 point)
    {
        asker.SetDestination(point);
    }
    public void followTarget(Interactable newTarget)
    {
        asker.stoppingDistance = newTarget.radius * 1f;
        asker.updateRotation = false;

        target = newTarget.interactionTransform;
    }
    public void stopFollowingTarget()
    {
        asker.stoppingDistance = 0f;
        asker.updateRotation = true;
        target = null;
    }
    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // throw new System.NotImplementedException();

        
    }


}
