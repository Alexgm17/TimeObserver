using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{

    public Text levelFinished;

    public GameObject transition;

    public static bool playerEndLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelFinished.gameObject.SetActive(true);
            playerEndLevel = true;
            CoinManager.levelCoinsCount = 0;
            transition.SetActive(true);
            Invoke("ChangeScene", 1f);
            playerEndLevel = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerEndLevel = false;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
