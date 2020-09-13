using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    //private bool isGameSet = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("GameSettings") == 2) return;
        SetScoreThresholds();
        SetTmpScores();
        SetScores();
        SetLevels();
        PlayerPrefs.SetInt("Currency", 0);
        PlayerPrefs.SetInt("Tutorial", 0);
        PlayerPrefs.SetInt("GameSettings", 1);
        PlayerPrefs.Save();
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
        PlayerPrefs.SetInt("MaxScore0", 5);
        PlayerPrefs.SetInt("MaxScore1", 15);
        PlayerPrefs.SetInt("MaxScore2", 30);
        PlayerPrefs.SetInt("MaxScore3", 50);
        PlayerPrefs.SetInt("MaxScore4", 75);
        PlayerPrefs.SetInt("MaxScore5", 100);
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
    public void SetDiplomas()
    {
        PlayerPrefs.SetInt($"Diploma1", 0);
        PlayerPrefs.SetInt($"Diploma2", 0);
        PlayerPrefs.SetInt($"Diploma3", 0);
        PlayerPrefs.SetInt($"Diploma4", 0);
        PlayerPrefs.SetInt($"Diploma5", 0);
        PlayerPrefs.SetInt($"Diploma6", 0);
    }
}
