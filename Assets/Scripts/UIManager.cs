using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public AudioSource clip;

    public GameObject optionsPanel;

    public void Update()
    {
        if (Input.GetKeyDown("escape") && optionsPanel.activeSelf == false)
        {
            OptionsPanel();
            PlaySoundButton();
        }
        else if (Input.GetKeyDown("escape") && optionsPanel.activeSelf == true)
        {
            Return();
            PlaySoundButton();
        }
    }

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void GoGameMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameMenu");
    }
    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();    
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }
}
