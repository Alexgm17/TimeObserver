using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{

    public Text levelFinished;

    public GameObject buttonOptions;

    public GameObject hearts;

    public GameObject coinsCount;

    public GameObject transition;

    public static bool playerEndLevel = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelFinished.gameObject.SetActive(true);
            playerEndLevel = true;
            CoinManager.levelCoinsCount = 0;
            StartCoroutine(LevelEndTransition());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerEndLevel = false;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        buttonOptions.gameObject.SetActive(true);
        hearts.gameObject.SetActive(true);
        coinsCount.gameObject.SetActive(true);
    }

    IEnumerator LevelEndTransition()
    {
        yield return new WaitForSeconds(1.5f);
        buttonOptions.gameObject.SetActive(false);
        hearts.gameObject.SetActive(false);
        coinsCount.gameObject.SetActive(false);
        levelFinished.gameObject.SetActive(false);
        transition.SetActive(true);
        Invoke("ChangeScene", 1f);
        playerEndLevel = false;
    }
}
