using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public PlayerController player;
    public int score;
    public Text scoreText;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        score = player.scorePoints;
        scoreText.text = "" + score;
    }
    void Update()
    {
        score = player.scorePoints;
        scoreText.text = "" + score;
    }
}
