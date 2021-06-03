using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDoorSkins : MonoBehaviour
{
    public Image image;
    public GameObject skinsPanel;
    private bool inDoor = false;
    public GameObject player;
    public AudioSource music;
    public AudioSource shop;
    public AudioSource jump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shop.Play();
            music.volume = 0.03f;
            image.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shop.Stop();
        music.Play();
        music.volume = 0.1f;
        image.gameObject.SetActive(false);
        skinsPanel.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if (skinsPanel.active)
        {
            image.gameObject.SetActive(false);
        }
        else if (inDoor)
        {
            image.gameObject.SetActive(true);

            if (Input.GetKey("e"))
            {
                jump.volume = 0;
                shop.volume = 0.1f;
                music.Stop();
                skinsPanel.gameObject.SetActive(true);
            }
        }
    }

    public void SetPlayerScientist()
    {
        PlayerPrefs.SetString("PlayerSelected","Scientist");
        ResetPlayerSkin();
    }

    public void SetPlayerMaskDude()
    {
        PlayerPrefs.SetString("PlayerSelected", "MaskDude");
        ResetPlayerSkin();
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelected", "Frog");
        ResetPlayerSkin();
    }

    public void SetPlayerPinkMan()
    {
        PlayerPrefs.SetString("PlayerSelected", "PinkMan");
        ResetPlayerSkin();
    }

    public void SetPlayerVirtualGuy()
    {
        PlayerPrefs.SetString("PlayerSelected", "VirtualGuy");
        ResetPlayerSkin();
    }

    void ResetPlayerSkin()
    {
        jump.volume = 0.5f;
        skinsPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }
}
