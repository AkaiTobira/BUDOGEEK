using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxScoreMenu : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject maxScoreMenu;
    public void PauseGameIfPlayerAchiveMaxScore()
    {
        levelManager.SaveLevelProgress();
        maxScoreMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueGameOnClick()
    {
        maxScoreMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void LoadNextLevelOnClick()
    {
        Time.timeScale = 1f;
        int tmp = PlayerPrefs.GetInt("CurrentLevel");
        tmp++;
        PlayerPrefs.SetInt("CurrentLevel", tmp);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
