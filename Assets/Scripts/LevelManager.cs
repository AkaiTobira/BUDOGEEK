using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public PlayerController player;
    public OpponentController opponent;
    public int currentLevel;
    public GameObject[] level;
    public int[] maxScores;
    public int maxScore;
    public Countdown countdown;
    public bool isGameStarted = false;
    public bool isReadyToContinue = true;
    //public DiplomasController diplomasController;
    //public Countdown countdown;
    void Start()
    {
        StartCoroutine(StartCounting());
        StartCoroutine(ActivateOpponents());
        player = FindObjectOfType<PlayerController>();
        opponent = FindObjectOfType<OpponentController>();
        DefineCurrentLevel();
    }
    void Update()
    {
        ChangeTechniqueButtonsDependingOnCurrentLevel();
        EndTutorial();
    }
    public void DefineCurrentLevel()
    {
        DefineCurrentLevelDependingOnChoice();
        //DefineCurrentLevelDependingOnProgress();
    }
    public void DefineCurrentLevelDependingOnProgress()//if PlayButton is clicked
    {
        switch (PlayerPrefs.GetInt("LastLevelPlayed"))
        {
            case 0:
                currentLevel = 1;
                PlayerPrefs.SetInt("LastLevelPlayed", currentLevel);
                break;
            case 1:
                currentLevel = 2;
                PlayerPrefs.SetInt("LastLevelPlayed", currentLevel);
                break;
            case 2:
                currentLevel = 3;
                PlayerPrefs.SetInt("LastLevelPlayed", currentLevel);
                break;
            case 3:
                currentLevel = 4;
                PlayerPrefs.SetInt("LastLevelPlayed", currentLevel);
                break;
            case 4:
                currentLevel = 5;
                PlayerPrefs.SetInt("LastLevelPlayed", currentLevel);
                break;
            case 5:
                currentLevel = 6;
                PlayerPrefs.SetInt("LastLevelPlayed", currentLevel);
                break;
            case 6:
                currentLevel = 6;
                PlayerPrefs.SetInt("LastLevelPlayed", currentLevel);
                break;
            default:
                break;
        }
    }
    public void DefineCurrentLevelDependingOnChoice()//if level is chosen from LevelMenu's buttons list
    {
        if (LevelMenu.levelMenu.isLevelChosen != null)
        {
            currentLevel = LevelMenu.levelMenu.chosenLevel;
            LevelMenu.levelMenu.isLevelChosen = false;
        }
    }
    IEnumerator StartCounting()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(countdown.CountingDown(3));
    }
    IEnumerator ActivateOpponents()
    {
        yield return new WaitForSeconds(5f);
        isGameStarted = true;
    }
    public void ChangeTechniqueButtonsDependingOnCurrentLevel()
    {
        foreach (var lvl in level)
            lvl.SetActive(false);
        level[currentLevel].SetActive(true);
    }
    public void SaveLevelProgress()
    {
        switch (currentLevel)
        {
            case 0:
                break;
            case 1:
                PlayerPrefs.SetInt("Score1", FindObjectOfType<ScoreSystem>().score);
                break;
            case 2:
                PlayerPrefs.SetInt("Score2", FindObjectOfType<ScoreSystem>().score);
                break;
            case 3:
                PlayerPrefs.SetInt("Score3", FindObjectOfType<ScoreSystem>().score);
                break;
            case 4:
                PlayerPrefs.SetInt("Score4", FindObjectOfType<ScoreSystem>().score);
                break;
            case 5:
                PlayerPrefs.SetInt("Score5", FindObjectOfType<ScoreSystem>().score);
                break;
            case 6:
                PlayerPrefs.SetInt("Score6", FindObjectOfType<ScoreSystem>().score);
                break;
            default:
                break;
        }
    }
    public void EndTutorial()
    {
        if (currentLevel == 0 && FindObjectOfType<ScoreSystem>().score == maxScores[currentLevel])
            StartCoroutine(EndingTutorial());
    }
    IEnumerator EndingTutorial()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /*
    public void CheckLevelProgress(int score)
    {
        if (score == maxScores[currentLevel] && isReadyToContinue)
            currentLevel++;
    }   
    */


    /*
    public void ShowDiplomaIfGainMaxScoreOfCurrentLevel()
    {
        if (player.scorePoints == maxScores[currentLevel])
            StartCoroutine(ShowDiploma());
    }
    IEnumerator ShowDiploma()
    {
        diplomasController.diplomas[currentLevel].GetComponent<Animator>().SetTrigger("showDiploma");
        yield return new WaitForSeconds(3f);
        StartCoroutine(countdown.CountingDown(3));
    }
    */
}
