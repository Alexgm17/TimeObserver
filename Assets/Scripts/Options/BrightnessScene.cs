using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessScene : MonoBehaviour
{
    public Image brightnessPanel;

    void Start()
    {
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, PlayerPrefs.GetFloat("Brightness", 0.5f));
    }
}
