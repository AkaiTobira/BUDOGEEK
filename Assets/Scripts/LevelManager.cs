using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public PlayerController player;
    public OpponentController opponent;
    public int currentLevel;
    public GameObject[] level;
    public int[] maxScores;
    public int maxScore;
    public Diploma diploma;
    public Countdown countdown;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        opponent = FindObjectOfType<OpponentController>();
        diploma = FindObjectOfType<Diploma>();
        countdown = FindObjectOfType<Countdown>();
    }
    void Update()
    {
        ChangeTechniqueButtonsDependingOnCurrentLevel();
    }
    public void ShowDiplomaIfGainMaxScoreOfCurrentLevel()
    {
        //diploma.diploma.SetActive(true);
        //Time.timeScale = 0f;
        if (player.scorePoints == maxScores[currentLevel])
            StartCoroutine(ShowDiploma());
    }
    IEnumerator ShowDiploma()
    {
        diploma.GetComponent<Animator>().SetTrigger("showDiploma");
        yield return new WaitForSeconds(3f);
        countdown.GetComponent<Animator>().SetTrigger("startCountingDown");
        countdown.CountingDown();
        countdown.GetComponent<Text>().text = "3";
        //yield return new WaitForSeconds(3f);
        //diploma.diploma.SetActive(false);
        //Time.timeScale = 1f;
    }
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
