using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int[] totalScores;
    public int indexOfAchievedBelt;
    public Text[] totalScoresText;
    public PlayerController playerController;
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTotalScore();
    }

    private void SetTotalScore()
    {
        int i = levelManager.currentLevel;
        if (playerController.scorePoints > totalScores[i])
        {
            totalScores[i] = playerController.scorePoints;
            totalScoresText[i].text = "" + totalScores[i];
        }
    }
}
