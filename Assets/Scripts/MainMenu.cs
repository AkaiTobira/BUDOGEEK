using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        SavePlayerProgress();
    }
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

    public void SavePlayerProgress()
    {
        for (int i = 0; i < 7; i++)
        {
            if (PlayerPrefs.GetInt($"Score{i}") > PlayerPrefs.GetInt($"HighScore{i}"))
                PlayerPrefs.SetInt($"HighScore{i}", PlayerPrefs.GetInt($"Score{i}"));
        }
    }
}
