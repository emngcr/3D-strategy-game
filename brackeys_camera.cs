using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class brackeys_camera : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public Vector3 offset;
    public float zoomSpeed =4f;
    public float maxZoom = 15f;
    public float minZoom = 5f;
    public float pitch = 2f;
    private float currentZoom = 10f;
    private float yawSpeed = 100f;
    private float currentYaw = 0f;

   
    void Update()
    {
        if (player.GetComponent<PhotonView>().IsMine)
        {
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        }
      
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (player.GetComponent<PhotonView>().IsMine)
        {
            transform.position = target.position - offset * currentZoom;
            transform.LookAt(target.position + Vector3.up * pitch);
            transform.RotateAround(target.position, Vector3.up, currentYaw);
        }
        
    }
}
