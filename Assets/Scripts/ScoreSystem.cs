using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public PlayerController player;
    public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        score = player.scorePoints;
        scoreText.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        score = player.scorePoints;
        scoreText.text = "" + score;
    }
}
