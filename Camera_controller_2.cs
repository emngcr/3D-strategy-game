using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller_2 : MonoBehaviour
{
    Camera cam;
    public float CamMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * zInput + transform.right * xInput;
        transform.position += dir * CamMoveSpeed * Time.deltaTime;




    }
}
