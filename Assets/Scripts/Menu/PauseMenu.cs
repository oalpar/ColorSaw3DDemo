using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused=false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public void Pause()
    {
        GameIsPaused=true;
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        GameIsPaused=false;
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
