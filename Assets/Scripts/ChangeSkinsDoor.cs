using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkinsDoor : MonoBehaviour
{
    public Image image;
    public GameObject skinsPanel;
    private bool inDoor = false;
    public GameObject player;
    public AudioSource music;
    public AudioSource shop;
    public AudioSource jump;
    public Image MaskDude;
    public Image Frog;
    public Image PinkMan;
    public Image VirtualGuy;
    public GameObject priceMaskDude;
    public GameObject priceFrog;
    public GameObject pricePinkMan;
    public GameObject priceVirtualGuy;
    public GameObject coinMaskDude;
    public GameObject coinFrog;
    public GameObject coinPinkMan;
    public GameObject coinVirtualGuy;
    public GameObject panelOptions;
    public Text totalCoins;
    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shop.Play();
            music.volume = 0.03f;
            image.gameObject.SetActive(true);
            inDoor = true;

            if (PlayerPrefs.HasKey("MaskDudeBought"))
            {
                MaskDude.color = new Color(1, 1, 1, 1);
                priceMaskDude.SetActive(false);
                coinMaskDude.SetActive(false);
            }

            if (PlayerPrefs.HasKey("FrogBought"))
            {
                Frog.color = new Color(1, 1, 1, 1);
                priceFrog.SetActive(false);
                coinFrog.SetActive(false);
            }

            if (PlayerPrefs.HasKey("PinkManBought"))
            {
                PinkMan.color = new Color(1, 1, 1, 1);
                pricePinkMan.SetActive(false);
                coinPinkMan.SetActive(false);
            }

            if (PlayerPrefs.HasKey("VirtualGuyBought"))
            {
                VirtualGuy.color = new Color(1, 1, 1, 1);
                priceVirtualGuy.SetActive(false);
                coinVirtualGuy.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shop.Stop();
        music.mute = false;
        music.volume = 0.1f;
        image.gameObject.SetActive(false);
        skinsPanel.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if (panelOptions.active)
        {
            image.gameObject.SetActive(false);
            skinsPanel.SetActive(false);
        }
        else
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
                    jump.mute = true;
                    shop.volume = 0.1f;
                    clip.Play();
                    music.mute = true;
                    skinsPanel.gameObject.SetActive(true);
                }
                else
                {
                    jump.mute = false;
                }
            }
        }
    }

    public void SetPlayerScientist()
    {
        PlayerPrefs.SetString("PlayerSelected", "Scientist");
        ResetPlayerSkin();
    }

    public void SetPlayerMaskDude()
    {
        if (PlayerPrefs.HasKey("MaskDudeBought"))
        {
            PlayerPrefs.SetString("PlayerSelected", "MaskDude");
            ResetPlayerSkin();
        }
        else if (CoinManager.globalCoinsCount >= 250)
        {
            CoinManager.globalCoinsCount -= 250;
            PlayerPrefs.SetInt("TotalCoins", CoinManager.globalCoinsCount);
            totalCoins.text = CoinManager.globalCoinsCount.ToString();
            PlayerPrefs.SetInt("MaskDudeBought", 1);
            MaskDude.color = new Color(1, 1, 1, 1);
            priceMaskDude.SetActive(false);
            coinMaskDude.SetActive(false);
            PlayerPrefs.SetString("PlayerSelected", "MaskDude");
            ResetPlayerSkin();
        }
        else
        {
            clip.Play();
        }
    }

    public void SetPlayerFrog()
    {
        if (PlayerPrefs.HasKey("FrogBought"))
        {
            PlayerPrefs.SetString("PlayerSelected", "Frog");
            ResetPlayerSkin();
        }
        else if (CoinManager.globalCoinsCount >= 750)
        {
            CoinManager.globalCoinsCount -= 750;
            PlayerPrefs.SetInt("TotalCoins", CoinManager.globalCoinsCount);
            totalCoins.text = CoinManager.globalCoinsCount.ToString();
            PlayerPrefs.SetInt("FrogBought", 1);
            Frog.color = new Color(1, 1, 1, 1);
            priceFrog.SetActive(false);
            coinFrog.SetActive(false);
            PlayerPrefs.SetString("PlayerSelected", "Frog");
            ResetPlayerSkin();
        }
        else
        {
            clip.Play();
        }
    }

    public void SetPlayerPinkMan()
    {
        if (PlayerPrefs.HasKey("PinkManBought"))
        {
            PlayerPrefs.SetString("PlayerSelected", "PinkMan");
            ResetPlayerSkin();
        }
        else if (CoinManager.globalCoinsCount >= 1000)
        {
            CoinManager.globalCoinsCount -= 1000;
            PlayerPrefs.SetInt("TotalCoins", CoinManager.globalCoinsCount);
            totalCoins.text = CoinManager.globalCoinsCount.ToString();
            PlayerPrefs.SetInt("PinkManBought", 1);
            PinkMan.color = new Color(1, 1, 1, 1);
            pricePinkMan.SetActive(false);
            coinPinkMan.SetActive(false);
            PlayerPrefs.SetString("PlayerSelected", "PinkMan");
            ResetPlayerSkin();
        }
        else
        {
            clip.Play();
        }
    }

    public void SetPlayerVirtualGuy()
    {
        if (PlayerPrefs.HasKey("VirtualGuyBought"))
        {
            PlayerPrefs.SetString("PlayerSelected", "VirtualGuy");
            ResetPlayerSkin();
        }
        else if (CoinManager.globalCoinsCount >= 2000)
        {
            CoinManager.globalCoinsCount -= 2000;
            PlayerPrefs.SetInt("TotalCoins", CoinManager.globalCoinsCount);
            totalCoins.text = CoinManager.globalCoinsCount.ToString();
            PlayerPrefs.SetInt("VirtualGuyBought", 1);
            VirtualGuy.color = new Color(1, 1, 1, 1);
            priceVirtualGuy.SetActive(false);
            coinVirtualGuy.SetActive(false);
            PlayerPrefs.SetString("PlayerSelected", "VirtualGuy");
            ResetPlayerSkin();
        }
        else
        {
            clip.Play();
        }
    }

    void ResetPlayerSkin()
    {
        jump.volume = 0.5f;
        skinsPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
        clip.Play();
    }
}
