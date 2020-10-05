using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiplomasController : MonoBehaviour
{
    public AudioSource diplomaSound;
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
        if (levelManager.currentLevel == 6) return;
        if (FindObjectOfType<ScoreSystem>().score == levelManager.maxScores[levelManager.currentLevel] &&
            PlayerPrefs.GetInt($"Diploma{levelManager.currentLevel}") == 0)
        {
            levelManager.SaveLevelProgress();
            FindObjectOfType<OpponentController>().doesAchieveMaxScore = true;
            diplomas[levelManager.currentLevel].GetComponent<Animator>().SetTrigger("showDiploma");
            diplomaSound.Play();
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
        FindObjectOfType<OpponentController>().doesAchieveMaxScore = false;
    }
}
