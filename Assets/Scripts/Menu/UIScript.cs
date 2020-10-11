using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class UIScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject deathScreen;
    public GameObject winScreen;
    public void LoadDeathScreen()
    {
        
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void LoadWinScreen()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
