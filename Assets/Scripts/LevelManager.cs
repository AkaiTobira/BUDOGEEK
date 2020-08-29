using System;
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
    public bool isReady = false;
    public GameObject tutorialLayer;
    public TutorialMenu tutorialMenu;

    void Start()
    {
        StartCoroutine(StartCounting());
        StartCoroutine(ActivateOpponents());
        player = FindObjectOfType<PlayerController>();
        opponent = FindObjectOfType<OpponentController>();
        DefineCurrentLevel();
        ChangeTechniqueButtonsDependingOnCurrentLevel();
        /*
        if (currentLevel == 0 && PlayerPrefs.GetInt("Tutorial") == 0)
            StartTutorial();*/
    }
    void Update()
    {
    }
    public void DefineCurrentLevel()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        PlayerPrefs.SetInt("LastLevelPlayed", currentLevel);
    }
    /*
    public void DefineCurrentLevelDependingOnChoice()//if level is chosen from LevelMenu's buttons list
    {
        Debug.Log(LevelMenu.levelMenu);
        if (LevelMenu.levelMenu.isLevelChosen)
        {
            currentLevel = LevelMenu.levelMenu.chosenLevel;
            LevelMenu.levelMenu.isLevelChosen = false;
        }
    }*/
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
                PlayerPrefs.SetInt("Score0", FindObjectOfType<ScoreSystem>().score);
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
    public void StartTutorial()
    {
        ShowIntroducingInformation();
    }
    public void ShowIntroducingInformation()
    {
        while (!isReady)
        {
            tutorialLayer.GetComponent<Animator>().SetTrigger("Welcome");
            if (Input.touches.Length != 0)
            {
                isReady = true;
            }
        }
        isReady = false;
        while (!isReady)
        {
            tutorialLayer.GetComponent<Animator>().SetTrigger("ShowHUD");
            if (Input.touches.Length != 0)
            {
                isReady = true;
            }
        }
        isReady = false;
        while (!isReady)
        {
            tutorialLayer.GetComponent<Animator>().SetTrigger("ShowBattle");
            if (Input.touches.Length != 0)
            {
                isReady = true;
            }
        }
        isReady = false;
    }
    IEnumerator WaitUntilBeingReadyToContinue()
    {
        yield return new WaitForSeconds(2f);
    }
    public void EndTutorial()
    {
        if (currentLevel == 0 && FindObjectOfType<ScoreSystem>().score == maxScores[currentLevel])
        {
            StartCoroutine(EndingTutorial());
        }
    }
    IEnumerator EndingTutorial()
    {
        SaveLevelProgress();
        yield return new WaitForSeconds(3f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        tutorialMenu.PauseGameIfPlayerHasFinishedTutorial();
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
