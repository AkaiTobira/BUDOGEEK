using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiplomasController : MonoBehaviour
{
    public GameObject[] diplomas;
    public PlayerController player;
    public LevelManager levelManager;
    public Countdown countdown;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    public void ShowDiplomaIfGainMaxScoreOfCurrentLevel()
    {
        if (FindObjectOfType<ScoreSystem>().score == levelManager.maxScores[levelManager.currentLevel-1])
        {
            FindObjectOfType<OpponentController>().isAchieveMaxScore = true;
            diplomas[levelManager.currentLevel].GetComponent<Animator>().SetTrigger("showDiploma");
            StartCoroutine(StartCounting());
            StartCoroutine(ActivateOpponents());
        }
    }
    IEnumerator StartCounting()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(countdown.CountingDown(3));
    }
    IEnumerator ActivateOpponents()
    {
        yield return new WaitForSeconds(7.5f);
        FindObjectOfType<OpponentController>().isAchieveMaxScore = false;
    }
}
