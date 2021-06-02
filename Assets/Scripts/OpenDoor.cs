using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Image image;
    public Image forbiddenImage;
    public string levelName;
    private bool inDoor = false;
    private bool unlockedWorld = false;
    private bool open = false;
    public GameObject transition;
    public AudioSource music;
    public AudioSource portal;
    public AudioSource jump;
    public AudioSource doorOpen;
    public GameObject canvas;
    public GameObject panelOptions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (levelName == "World2Level1" && !PlayerPrefs.HasKey("UnlockWorld2") || levelName == "World3Level1" && !PlayerPrefs.HasKey("UnlockWorld3"))
            {
                forbiddenImage.gameObject.SetActive(true);
                inDoor = true;
            }
            else
            {
                portal.Play();
                music.volume = 0.03f;
                image.gameObject.SetActive(true);
                inDoor = true;
                unlockedWorld = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        portal.Stop();
        music.volume = 0.1f;
        image.gameObject.SetActive(false);
        forbiddenImage.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if (panelOptions.active || transition.active)
        {
            image.gameObject.SetActive(false);
            forbiddenImage.gameObject.SetActive(false);
        }
        else if (inDoor)
        {
            if (levelName == "World2Level1" && !PlayerPrefs.HasKey("UnlockWorld2") || levelName == "World3Level1" && !PlayerPrefs.HasKey("UnlockWorld3"))
            {
                forbiddenImage.gameObject.SetActive(true);
            }
            else
            {
                image.gameObject.SetActive(true);
            }

            if (Input.GetKey("e") && unlockedWorld)
            {
                jump.volume = 0;
                portal.Stop();
                music.Stop();
                if (open == false)
                {
                    doorOpen.Play();
                    open = true;
                }
                canvas.gameObject.SetActive(false);
                transition.SetActive(true);
                Invoke("ChangeScene", 1f);
            }
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(levelName);
    }
}