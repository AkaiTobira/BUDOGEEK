using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject tutorialMenu;
    public void PauseGameIfPlayerHasFinishedTutorial()
    {
        levelManager.SaveLevelProgress();
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            PlayerPrefs.SetInt("Tutorial", 1);
            PlayerPrefs.SetInt("FinishedTutorial", 1);
        }
        tutorialMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueGameOnClick()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("CurrentLevel", 1);
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
