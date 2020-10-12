using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diploma : MonoBehaviour
{
    public Text scoreText;
    public Text jenText;
    public PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        //scoreText.text = "" + player.scorePoints;
        //scoreText.text = "" + player.jenCoins;
    }
    void Update()
    {
        player = FindObjectOfType<PlayerController>();
        //scoreText.text = "" + player.scorePoints;
        //scoreText.text = "" + player.jenCoins;
    }
}
