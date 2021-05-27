using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        AudioListener.volume = slider.value;
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("Volume", sliderValue);
        AudioListener.volume = slider.value;
    }
}
