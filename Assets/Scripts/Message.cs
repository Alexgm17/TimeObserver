using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public GameObject image;
    public GameObject key;
    public GameObject text;
    public AudioSource jump;
    public static bool hasrun;
    public AudioSource audio;
    public GameObject optionsPanel;

    void Start()
    {
        if (!hasrun)
        {
            Time.timeScale = 0;
            jump.mute = true;
            image.gameObject.SetActive(true);
            key.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            hasrun = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("e") || optionsPanel.active == true)
        {
            Time.timeScale = 1;
            jump.mute = false;
            image.gameObject.SetActive(false);
            key.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            gameObject.GetComponent<Message>().enabled = false;
            audio.Play();

        }
    }
}
