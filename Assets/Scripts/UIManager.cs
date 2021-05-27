using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public AudioSource clip;

    public AudioSource music;

    public GameObject optionsPanel;

    public GameObject menuButton;

    public GameObject transition;

    public GameObject hearts;

    public GameObject coins;

    public AudioSource player;

    public void Update()
    {
        if (Input.GetKeyDown("escape") && optionsPanel.activeSelf == false)
        {
            OptionsPanel();
        }
        else if (Input.GetKeyDown("escape") && optionsPanel.activeSelf == true)
        {
            Return();
        }
    }

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        player.mute = true;
        optionsPanel.SetActive(true);
        clip.Play();
    }

    public void Return()
    {
        Time.timeScale = 1;
        player.mute = false;
        optionsPanel.SetActive(false);
        clip.Play();
    }

    public void GoGameMenu()
    {
        Time.timeScale = 1;
        music.Stop();
        clip.Play();
        optionsPanel.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false); 
        hearts.gameObject.SetActive(false);
        coins.gameObject.SetActive(false);
        transition.SetActive(true);
        Invoke("ChangeSceneGameMenu", 1f);
    }
    public void GoMainMenu()
    {
        Time.timeScale = 1;
        music.Stop();
        clip.Play();
        optionsPanel.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        hearts.gameObject.SetActive(false);
        coins.gameObject.SetActive(false);
        transition.SetActive(true);
        Invoke("ChangeSceneMainMenu", 1f);
    }

    void ChangeSceneGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    void ChangeSceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
