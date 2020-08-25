using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        if (PlayerPrefs.GetInt("Tutorial") == 1 && PlayerPrefs.GetInt("LastLevelPlayed") != 0)
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("LastLevelPlayed"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
