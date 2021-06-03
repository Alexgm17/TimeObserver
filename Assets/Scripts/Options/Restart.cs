using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Toggle toggle;
    public GameObject backButton;
    public GameObject restartButton;

    void Start()
    {
        toggle.isOn = false;
    }

    void Update()
    {
        if (toggle.isOn)
        {
            backButton.SetActive(false);
            restartButton.SetActive(true);
        }
        else
        {
            backButton.SetActive(true);
            restartButton.SetActive(false);
        }
    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteKey("TotalCoins");
        PlayerPrefs.DeleteKey("UnlockWorld2");
        PlayerPrefs.DeleteKey("UnlockWorld3");
        PlayerPrefs.DeleteKey("MaskDudeBought");
        PlayerPrefs.DeleteKey("FrogBought");
        PlayerPrefs.DeleteKey("PinkManBought");
        PlayerPrefs.DeleteKey("VirtualGuyBought");
        PlayerPrefs.DeleteKey("PlayerSelected");
    }
}