using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class baris_ui : MonoBehaviour 
{
    
    public Slider slider;

    /* private void Update()
     {
         if (GetComponent<PhotonView>().IsMine)
         {
             this.GetComponent<PhotonView>().RPC("SetMaxHealth", RpcTarget.AllBuffered);
             this.GetComponent<PhotonView>().RPC("SetHealth", RpcTarget.AllBuffered);
         }
     }*/
    
    public void SetMaxHealth(int health)
    {
        
            slider.maxValue = health;
            slider.value = health;
        
            
    }

  
    public void SetHealth(int health)
    {
        
            slider.value = health;
        
    }

  
}

