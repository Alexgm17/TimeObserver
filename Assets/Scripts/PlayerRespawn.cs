using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    public GameObject[] hearts;
    private int life;

    private float checkPositionX, checkPositionY;

    public Animator animator;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (life < 2)
        {
            hearts[1].gameObject.SetActive(false);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
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
        life--;
        CheckLife();
    }
}
