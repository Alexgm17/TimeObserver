using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerRespawn : MonoBehaviour
{
    public AudioSource clip;

    public GameObject[] hearts;

    private int life;

    private float checkPositionX, checkPositionY;

    public Animator animator;

    private float timeInmunity;

    private void Start()
    {
        life = hearts.Length;

        if (PlayerPrefs.GetFloat("checkPositionX")!=0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void CheckLife()
    {
        if (life < 1)
        {
            hearts[0].gameObject.SetActive(false);
            animator.Play("Hit");
            CoinManager.globalCoinsCount -= CoinManager.levelCoinsCount;
            CoinManager.levelCoinsCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            life--;
            timeInmunity = 0;
            CheckLife();
        }
    }

    public void Update()
    {
        timeInmunity += Time.deltaTime;
    }
}
