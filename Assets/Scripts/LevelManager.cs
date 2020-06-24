using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerController gamePlayer;
    public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.gameObject.SetActive(false);
        Debug.Log("Game over!");
        Debug.Log("Your score is: " + gamePlayer.score);
        Debug.Log("Try again :D");
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.hitPoints = 3;
        gamePlayer.gameObject.SetActive(true);
    }

    public void Scoring(int numberOfPoints)
    {
        //póki co tak, na ogół te wartości w lvman
        score += numberOfPoints;
        scoreText.text = "Score: " + score;
    }
}
