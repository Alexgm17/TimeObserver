using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public TMP_Text text;
    public GameObject startScreen;

    public void LoadGame()
    {
        startScreen.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        Invoke("ChangeScene", 1f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
