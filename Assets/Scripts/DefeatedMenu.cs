using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DefeatedMenu : MonoBehaviour
{
    public LevelManager levelManager;
    public Text scoreText;
    public int scorePoints;
    public PlayerController player;
    public GameObject defeatMenu;
    public ScoreSystem scoreSystem;
    public void PauseGameIfPlayerIsDefeted()
    {
        levelManager.SaveLevelProgress();
        defeatMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void TryAgainOnClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        scoreText.text = "Wynik: " + scoreSystem.score;
    }
    void Update()
    {
        scoreText.text = "Wynik: " + scoreSystem.score;
    }

}
