using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    public float CamMoveSpeed;
    public Transform target;
   

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        Cmove();
        
       
    }
   

    void Cmove()
    {
       

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * zInput + transform.right * xInput;
        transform.position += dir* CamMoveSpeed * Time.deltaTime;

       
    }
   
    public void FocusOnPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}
