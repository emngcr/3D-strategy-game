using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(CharacterStats))]
public class UIscript : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;
    float visTime = 5;
    float lastvisTime ;

    Transform ui;
    Image slider;
    Transform cam;
    

     void Start()
    {
        cam = Camera.main.transform;
       
        foreach(Canvas c in FindObjectsOfType<Canvas>())
        {
            if(c.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(uiPrefab, c.transform).transform;
                slider = ui.GetChild(0).GetComponent<Image>();
                ui.gameObject.SetActive(false);
                break;
            }
        }
        //GetComponent<CharacterStats>().healthChanged += healthChanged;
    }
    void healthChanged (int health , int currentHealth)
    {
        if (ui != null)
        {
            ui.gameObject.SetActive(true);

            lastvisTime = Time.time;
            float healthPercent = (float)currentHealth / health;
            slider.fillAmount = healthPercent;

            if (currentHealth <= 0)
            {
                Destroy(ui.gameObject);
            }
        }
    }
     void LateUpdate()
    {
        if (ui != null)
        {
            ui.position = target.position;
            ui.forward = -cam.forward;
            if ( Time.time - lastvisTime > visTime)
            {
                ui.gameObject.SetActive(false);
            }
        }
    }
}
