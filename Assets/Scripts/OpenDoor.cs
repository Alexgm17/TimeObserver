using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public TMP_Text text;
    public string levelName;
    private bool inDoor = false;
    private bool open = false;
    public GameObject transition;
    public AudioSource music;
    public AudioSource jump;
    public AudioSource doorOpen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if (inDoor && Input.GetKey("e"))
        {
            jump.volume = 0;
            music.Stop();
            if (open == false)
            {
                doorOpen.Play();
                open = true;
            }
            text.gameObject.SetActive(false);
            transition.SetActive(true);
            Invoke("ChangeScene", 1f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
