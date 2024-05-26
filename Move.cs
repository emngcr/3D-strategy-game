using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PlayerMotor))]
public class Move : MonoBehaviour 
{
    public Interactable focus;

    Camera cam;
    public LayerMask movementMask;
    PlayerMotor motor;
    public GameObject playerCam;
    public GameObject playerCanvas;

    void Awake()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            playerCam.SetActive(true);
            playerCanvas.SetActive(true);

        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor= GetComponent<PlayerMotor>();
    }

    void Update()
    {
        /* if (Input.GetMouseButtonDown(1))// týklanan noktaya gider
          {
              Ray ray = cam.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              if(Physics.Raycast(ray,out hit,100, movementMask))
              {
                  motor.moveToPoint(hit.point);

                  removeFocus();
              }
          }
          if (Input.GetMouseButtonDown(0))//etkileþime girer
          {
              Ray ray = cam.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              if (Physics.Raycast(ray, out hit))
              {
                  // interaction
                  Interactable interact = hit.collider.GetComponent<Interactable>();
                  if(interact != null)
                  {
                      setFocus(interact);
                  }
               }
          }
           void setFocus(Interactable newFocus)
          {
              if (newFocus != focus)
              {
                  if (focus != null)
                  {
                      focus.onDeFocused();
                  }
                  focus = newFocus;
                  motor.followTarget(newFocus);

              }


              newFocus.onFocused(transform);
          }
          void removeFocus()
          {

              if (focus != null)
              {
                  focus.onDeFocused();
              }
              focus = null;
              motor.stopFollowingTarget();
          }*/
        if (GetComponent<PhotonView>().IsMine)
        {
            movePlayer();
        }

    }
   
    void movePlayer()
    {
        if (Input.GetMouseButtonDown(1))// týklanan noktaya gider
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.moveToPoint(hit.point);

                removeFocus();
            }
        }
        if (Input.GetMouseButtonDown(0))//etkileþime girer
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("1");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("2");
                // interaction
                Interactable interact = hit.collider.GetComponent<Interactable>();
                if (interact != null)
                {
                    Debug.Log("3");
                    setFocus(interact);
                }
            }
        }
        void setFocus(Interactable newFocus)
        {
            if (newFocus != focus)
            {
                if (focus != null)
                {
                    focus.onDeFocused();
                }
                focus = newFocus;
                motor.followTarget(newFocus);

            }


            newFocus.onFocused(transform);
        }
        void removeFocus()
        {

            if (focus != null)
            {
                focus.onDeFocused();
            }
            focus = null;
            motor.stopFollowingTarget();
        }
    }
  

}
