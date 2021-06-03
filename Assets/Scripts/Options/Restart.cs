using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Toggle toggle;
    public GameObject backButton;
    public GameObject restartButton;
    public GameObject restartScreen;
    public GameObject startScreen;
    public GameObject restartingText;

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
        restartScreen.SetActive(false);
        restartingText.SetActive(true);
        Invoke("DeletePlayerPrefs", 1f);
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteKey("TotalCoins");
        PlayerPrefs.DeleteKey("UnlockWorld2");
        PlayerPrefs.DeleteKey("UnlockWorld3");
        PlayerPrefs.DeleteKey("MaskDudeBought");
        PlayerPrefs.DeleteKey("FrogBought");
        PlayerPrefs.DeleteKey("PinkManBought");
        PlayerPrefs.DeleteKey("VirtualGuyBought");
        PlayerPrefs.DeleteKey("PlayerSelected");
        PlayerPrefs.DeleteKey("World1Level4Message");
        PlayerPrefs.DeleteKey("World2Level1Message");
        PlayerPrefs.DeleteKey("World3Level1Message");
        restartingText.SetActive(false);
        startScreen.SetActive(true);
    }
}