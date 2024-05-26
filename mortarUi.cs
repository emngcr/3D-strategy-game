using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mortarUi : MonoBehaviour
{
    public Slider image1;

    public void StartCooldown(float mortarCount)
    {
        image1.maxValue = mortarCount;
        image1.value = mortarCount;
    }
    public void Cooldown(float mortarCount)
    {
        image1.value = mortarCount;
    }

}
