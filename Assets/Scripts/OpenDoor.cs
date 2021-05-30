using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Image image;
    public string levelName;
    private bool inDoor = false;
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
            portal.Play();
            music.volume = 0.03f;
            image.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        portal.Stop();
        music.volume = 0.1f;
        image.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if (panelOptions.active || transition.active)
        {
            image.gameObject.SetActive(false);
        }
        else
        {
            if (inDoor)
            {
                image.gameObject.SetActive(true);
            }
        }

        if (inDoor && Input.GetKey("e"))
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

    private void ChangeScene()
    {
        SceneManager.LoadScene(levelName);
    }
}