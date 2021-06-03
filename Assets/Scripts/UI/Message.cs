using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Message : MonoBehaviour
{
    public GameObject image;
    public GameObject key;
    public GameObject text;
    public AudioSource jump;
    public AudioSource audio;
    public GameObject optionsPanel;
    public GameObject messageBackground;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (!PlayerPrefs.HasKey(sceneName + "Message"))
        {
            PlayerPrefs.SetInt(sceneName + "Message", 1);

            Time.timeScale = 0;
            jump.mute = true;
            messageBackground.gameObject.SetActive(true);
            image.gameObject.SetActive(true);
            key.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("e") || optionsPanel.active == true)
        {
            Time.timeScale = 1;
            jump.mute = false;
            messageBackground.gameObject.SetActive(false);
            image.gameObject.SetActive(false);
            key.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            gameObject.GetComponent<Message>().enabled = false;
            audio.Play();

        }
    }
}
