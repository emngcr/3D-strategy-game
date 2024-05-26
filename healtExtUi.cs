using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class healtExtUi : MonoBehaviour
{
    public Slider image2;
    [PunRPC]
    public void StartBandagePack(float bandageCount)
    {
        image2.maxValue = bandageCount;
        image2.value = bandageCount;
    }
    [PunRPC]
    public void BandagePack(float bandageCount)
    {
        image2.value = bandageCount;
    }

}
