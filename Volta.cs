using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Volta : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField]
    private Transform[] waypoints = new Transform[3];
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        i = 0;
        StartCoroutine(CycleWaypoint());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator CycleWaypoint()
    {
        while (true)
        {
            agent.SetDestination(waypoints[i].position);
            if (i < waypoints.Length)
            {
                if (Vector3.Distance(transform.position, waypoints[i].position) <= 2.1f)
                {
                    if (i == waypoints.Length - 1)
                    {
                        i = 0;
                    }
                    else
                        i++;
                }
            }
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }
}