using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EndLastLevel : MonoBehaviour
{
    public AudioSource clip;

    public Text levelFinished;

    public GameObject canvas;

    public GameObject transition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (EndLevel.playerEndLevel == false)
            {
                clip.Play();
                levelFinished.gameObject.SetActive(true);
                EndLevel.playerEndLevel = true;
                CoinManager.levelCoinsCount = 0;
                StartCoroutine(LevelEndTransition());
            }
        }
    }

    void ChangeScene()
    {
        EndLevel.playerEndLevel = false;
        SceneManager.LoadScene("GameMenu");
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
