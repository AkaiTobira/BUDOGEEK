﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRanking : MonoBehaviour
{
    public Text[] totalScoresText;
    public void Start()
    {
        SetTotalScore();
    }
    private void SetTotalScore()
    {
        for (int i = 0; i < totalScoresText.Length; i++)
        {
            totalScoresText[i].text += "" + PlayerPrefs.GetInt($"HighScore{i+1}");
        }
    }
}
