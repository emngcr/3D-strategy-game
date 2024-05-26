using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemySpawnBase : MonoBehaviour
{
    public GameObject enemy;
    public float callRadius;
    private int i = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawn();
    }

  public  void enemySpawn()
    {
       
      
        var enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (var enemy in enemies)
        {
            if(Vector3.Distance(enemy.transform.position , transform.position) <= callRadius)
            {
                if(enemy.GetComponent<EnemyStats>().currentHealth < 100 || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().currentHealth < 100 )
                {
                    while (i < 3)
                    {
                       PhotonNetwork.Instantiate("dusmanV2", transform.position, Quaternion.identity);
                        i++;
                    }
                   
                   
                }
            }
        }
        
    }

    
         
}
