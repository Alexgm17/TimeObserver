using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EndLevel : MonoBehaviour
{
    public AudioSource clip;

    public Text levelFinished;

    public GameObject canvas;

    public GameObject transition;

    public static bool playerEndLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerEndLevel == false) {
                clip.Play();
                levelFinished.gameObject.SetActive(true);
                playerEndLevel = true;
                CoinManager.levelCoinsCount = 0;
                StartCoroutine(LevelEndTransition());
            }
        }
    }

    void ChangeScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "World1Level4")
        {
            PlayerPrefs.SetInt("UnlockWorld2", 1);
        }
        else if (sceneName == "World2Level4")
        {
            PlayerPrefs.SetInt("UnlockWorld3", 1);
        }

        playerEndLevel = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LevelEndTransition()
    {
        yield return new WaitForSeconds(1.5f);
        canvas.gameObject.SetActive(false);
        levelFinished.gameObject.SetActive(false);
        transition.SetActive(true);
        Invoke("ChangeScene", 1f);
    }
}
