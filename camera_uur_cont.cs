using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_uur_cont: MonoBehaviour
{
    [Header("Transformlar")]
    public Transform player;
    public Transform transform;

    [Header("Kamera Hýz Ayarlarý")]
    public float zoomSpeed;
    public float moveSpeed;
    public float rotateSpeed;
    [Header("Kamera Yükseklik Ayarlarý")]
    public float minHeight;
    public float maxHeight;

    private Vector3 velocity = Vector3.zero;
    public float SmoothTime = 0.3f;
    public Vector3 Offset;
    bool heightLock = true;

    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - player.position;
       // transform.position = player.position - Offset * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            heightLock = !heightLock;
        }

        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");

        Vector3 hareketVektörü = new Vector3(zAxisValue, 0.0f, -xAxisValue);

        hareketVektörü = transform.TransformDirection(hareketVektörü);
        //cameraParent.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));
        //cameraParent.transform.Translate(Vector3.Lerp(cameraParent.position,vektörr,Time.deltaTime * 10));

        transform.position = (Vector3.Lerp(transform.position, transform.position + hareketVektörü, Time.deltaTime * moveSpeed));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.transform.position = new Vector3(player.position.x, transform.transform.position.y, player.position.z);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(player.transform.position, transform.up, rotateSpeed * Time.deltaTime * 90f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(player.transform.position,transform.up, rotateSpeed * Time.deltaTime * -90f);
        }



    }
    private void LateUpdate()
    {
        if (heightLock)
        {
            Vector3 targetPosition = player.position + Offset;
            targetPosition = new Vector3(transform.position.x, targetPosition.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                //vektör = new Vector3(cameraParent.position.x, cameraParent.position.y * zoomSpeed * Time.deltaTime, cameraParent.position.z);
                //cameraParent.position = Vector3.Lerp(cameraParent.position, cameraParent.position + vektör, 1);
                transform.position += new Vector3(0, transform.position.y * zoomSpeed * Time.deltaTime, 0);
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                transform.position -= new Vector3(0, transform.position.y * zoomSpeed * Time.deltaTime, 0);
            }
        }
        //cameraParent.position = new Vector3(cameraParent.position.x, Mathf.Clamp(cameraParent.position.y, minHeight, maxHeight), cameraParent.position.z);


    }
}
