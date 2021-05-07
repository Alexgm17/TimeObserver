using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;

    public bool optionsPanelActive = false;

    public void Update()
    {
        if (Input.GetKeyDown("escape") && optionsPanelActive == false)
        {
            OptionsPanel();
        }
        else if (Input.GetKeyDown("escape") && optionsPanelActive == true)
        {
            Return();
        }
    }

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanelActive = true;
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanelActive = false;
        optionsPanel.SetActive(false);
    }

    public void AnotherOptions()
    {
        //Sound
        //Graphics
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("");
    }

    public void QuitGame()
    {
        Application.Quit();    
    }
}
