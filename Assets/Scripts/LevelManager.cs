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
    public bool IsGameStarted = false;
    //public DiplomasController diplomasController;
    //public Countdown countdown;
    void Start()
    {
        StartCoroutine(StartCounting());
        StartCoroutine(ActivateOpponents());
        player = FindObjectOfType<PlayerController>();
        opponent = FindObjectOfType<OpponentController>();
        //diplomasController = FindObjectOfType<DiplomasController>();
        //countdown = FindObjectOfType<Countdown>();
    }
    void Update()
    {
        ChangeTechniqueButtonsDependingOnCurrentLevel();
    }
    IEnumerator StartCounting()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(countdown.CountingDown(3));
    }
    IEnumerator ActivateOpponents()
    {
        yield return new WaitForSeconds(7f);
        IsGameStarted = true;
    }
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
    public void ChangeTechniqueButtonsDependingOnCurrentLevel()
    {
        foreach (var lvl in level)
            lvl.SetActive(false);
        level[currentLevel].SetActive(true);
    }
    public void CheckLevelProgress(int score)
    {
        if (score > maxScores[currentLevel])
            currentLevel++;
    }    
}
