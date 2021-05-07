using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{

    public Text levelFinished;

    public static bool playerEndLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelFinished.gameObject.SetActive(true);
            playerEndLevel = true;
            CoinManager.levelCoinsCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            playerEndLevel = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerEndLevel = false;
    }
}
