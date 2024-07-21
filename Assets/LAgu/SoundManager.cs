using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sumberSuara;
    private bool isMusicOn = true;
    private float lastSliderValue = 1f;

    public void KetikaSliderDiubah(float nilaiSlider)
    {
        if (isMusicOn)
        {
            sumberSuara.volume = nilaiSlider;
        }
        else if (nilaiSlider > 0f)
        {
            isMusicOn = true;
            sumberSuara.volume = nilaiSlider;
        }

        lastSliderValue = nilaiSlider;
    }

    public void MatikanMusik()
    {
        isMusicOn = false;
        sumberSuara.volume = 0f;
    }

    public void HidupkanMusik()
    {
        isMusicOn = true;
        sumberSuara.volume = lastSliderValue;
    }
}
