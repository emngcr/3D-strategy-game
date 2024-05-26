using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CharacterStats : MonoBehaviour 
{
    public int Health=100;
    public int currentHealth;
    public Stats damage;

   

    void Awake()
    {
        currentHealth = Health;
        
    }
    void Update()
    {

      currentHealth = Mathf.Clamp(currentHealth, 0, 1000);
        
    }
   /* public void check()
    {
        if (GetComponent<PhotonView>().IsMine && currentHealth <= 0)
        {
            
            this.GetComponent<PhotonView>().RPC("Die", RpcTarget.AllBuffered);
            
        }
    }*/
  

    [PunRPC]
    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage ");


          if (GetComponent<PhotonView>().IsMine && currentHealth <= 0)
          {
            //Die();
            this.GetComponent<PhotonView>().RPC("Die", RpcTarget.AllBuffered,null);
        }
       // check();
    }
    [PunRPC]
    public virtual void Die()
    {
        Debug.Log(transform.name + " died ");
    }
  
}
