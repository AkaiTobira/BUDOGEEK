using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int score;
    public Text scoreText;
    void Start()
    {
        score = 0;
        scoreText.text = "" + score;
    }
    public void AddToScore(int value)
    {
        score += value;
        scoreText.text = "" + score;
        FindObjectOfType<LevelManager>().ShowDiplomaIfGainMaxScoreOfCurrentLevel();
        FindObjectOfType<LevelManager>().CheckLevelProgress(score);
    }
}
