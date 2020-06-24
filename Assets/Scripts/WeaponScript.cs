using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private LevelManager gameLevelManager;
    private PlayerController gamePlayer;
    public int weaponValue;

    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
        gamePlayer       = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gamePlayer.GetComponent<Animator>().tag == "StandingAnimation")
            {
                gameLevelManager.Scoring(weaponValue);
            }
            //Destroy(gameObject);
        }
        /*
        //it makes sense here if we collect sth
        Debug.Log("Triggered");
        Destroy(gameObject);
        hitPoints--;
        Debug.Log("HP: " + hitPoints);
        //
        
        if (collision.tag == "Player")
            Destroy(gameObject);
        //reszta w lvman
        Debug.Log("Triggered");
        hitPoints--;
        Debug.Log("HP: " + hitPoints);
        */
    }
}
