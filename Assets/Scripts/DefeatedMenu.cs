using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatedMenu : MonoBehaviour
{
    public Text scoreText;
    public PlayerController player;
    public GameObject defeatMenu;
    public void PauseGameIfPlayerIsDefeted()
    {
        defeatMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void TryAgainOnClick(GameObject defeatedMenuUI)
    {
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
        scoreText.text = "Wynik: " + player.scorePoints;
    }
    void Update()
    {
        scoreText.text = "Wynik: " + player.scorePoints;
    }

}
