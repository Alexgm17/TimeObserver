using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerRespawn : MonoBehaviour
{
    public AudioSource clip;

    public GameObject[] hearts;

    public GameObject buttonOptions;

    public GameObject heartsUI;

    public GameObject coinsCount;

    public SpriteRenderer scientistColor;

    private int life;

    private float checkPositionX, checkPositionY;

    public Animator animator;

    public GameObject transition;

    private float timeInmunity;

    public static bool playerDead = false;

    private void Start()
    {
        life = hearts.Length;

        scientistColor = GetComponent<SpriteRenderer>();

        if (PlayerPrefs.GetFloat("checkPositionX")!=0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void CheckLife()
    {
        if (life < 1)
        {
            playerDead = true;
            scientistColor.color = new Color(1, 1, 1, 0);
            hearts[0].gameObject.SetActive(false);
            animator.Play("Hit");
            CoinManager.globalCoinsCount -= CoinManager.levelCoinsCount;
            CoinManager.levelCoinsCount = 0;
            buttonOptions.gameObject.SetActive(false);
            heartsUI.gameObject.SetActive(false);
            coinsCount.gameObject.SetActive(false);
            transition.SetActive(true);
            Invoke("ChangeScene", 1f);
        }
        else if (life < 2)
        {
            clip.Play();
            hearts[1].gameObject.SetActive(false);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
            clip.Play();
            hearts[2].gameObject.SetActive(false);
            animator.Play("Hit");
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        if (timeInmunity >= 1)
        {
            life++;
            timeInmunity = 0;
            CheckLife();
            scientistColor.color = new Color(1, 1, 1, 0.4f);
            Invoke("ChangeColor", 1f);
        }
    }

    public void Update()
    {
        timeInmunity += Time.deltaTime;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerDead = false;
        buttonOptions.gameObject.SetActive(true);
        heartsUI.gameObject.SetActive(true);
        coinsCount.gameObject.SetActive(true);
    }

    void ChangeColor()
    {
        scientistColor.color = new Color(1, 1, 1, 1);
    }
}
