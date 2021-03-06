﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public LevelManager levelManager;
    //public static bool IsGamePaused = false;
    public void PauseGameOnClick(GameObject pauseMenu)
    {
        levelManager.SaveLevelProgress();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //IsGamePaused = true;
    }
    public void ResumeGameOnClick(GameObject pauseMenu)
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //IsGamePaused = false;
    }
    public void GoToMainMenu()
    {
        //IsGamePaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        //IsGamePaused = false;
        Application.Quit();
    }
}
