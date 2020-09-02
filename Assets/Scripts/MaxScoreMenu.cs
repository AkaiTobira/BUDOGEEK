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
        if (PlayerPrefs.GetInt($"Score{levelManager.currentLevel}") == PlayerPrefs.GetInt($"MaxScore{levelManager.currentLevel}"))
        {
            StartCoroutine(GainMaxScore());
        }
    }
    IEnumerator GainMaxScore()
    {
        yield return new WaitForSeconds(3f);
        maxScoreMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueGameOnClick()
    {
        Time.timeScale = 1f;
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
