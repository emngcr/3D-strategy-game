using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus=false;

    Transform player;
    bool hasInteract=false;

    public Transform interactionTransform;
    void Start()
    {
        
    }

    public virtual void Interacted()
    {
        //�st�ne yaz�lmak i�in yap�ld�.
        Debug.Log("�unla etkile�imde " + transform.name);
    }
    void Update()
    {
        if (isFocus && !hasInteract)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance<= radius)
            {
                Interacted();
                hasInteract = true;
            }
        }
        
    }
    public void onFocused(Transform playerTransform)
    {
        
        isFocus = true;
        player = playerTransform;
        hasInteract = false;
    }
    public void onDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteract = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
