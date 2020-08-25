using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    //private bool isGameSet = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("GameSettings") == 1)
            PlayerPrefs.SetInt("GameSettings", 1);
        else
            PlayerPrefs.SetInt("GameSettings", 0);
        if (PlayerPrefs.GetInt("GameSettings") == 0)
        {
            SetScoreThresholds();
            SetTmpScores();
            SetScores();
            SetLevels();
            PlayerPrefs.SetInt("Currency", 0);
            PlayerPrefs.SetInt("Tutorial", 0);
            //isGameSet = true;
            PlayerPrefs.SetInt("GameSettings", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetLevels()
    {
        PlayerPrefs.SetInt("CurrentLevel", 0);
        PlayerPrefs.SetInt("LastLevelPlayed", 0);
    }
    public void SetScoreThresholds()
    {
        PlayerPrefs.SetInt("MaxScore0", 10);
        PlayerPrefs.SetInt("MaxScore1", 25);
        PlayerPrefs.SetInt("MaxScore2", 50);
        PlayerPrefs.SetInt("MaxScore3", 100);
        PlayerPrefs.SetInt("MaxScore4", 200);
        PlayerPrefs.SetInt("MaxScore5", 300);
        PlayerPrefs.SetInt("MaxScore6", 500);
    }
    public void SetTmpScores()
    {
        PlayerPrefs.SetInt("HighScore0", 0);
        PlayerPrefs.SetInt("HighScore1", 0);
        PlayerPrefs.SetInt("HighScore2", 0);
        PlayerPrefs.SetInt("HighScore3", 0);
        PlayerPrefs.SetInt("HighScore4", 0);
        PlayerPrefs.SetInt("HighScore5", 0);
        PlayerPrefs.SetInt("HighScore6", 0);
    }
    public void SetScores()
    {
        PlayerPrefs.SetInt("Score0", 0);
        PlayerPrefs.SetInt("Score1", 0);
        PlayerPrefs.SetInt("Score2", 0);
        PlayerPrefs.SetInt("Score3", 0);
        PlayerPrefs.SetInt("Score4", 0);
        PlayerPrefs.SetInt("Score5", 0);
        PlayerPrefs.SetInt("Score6", 0);
    }
}
