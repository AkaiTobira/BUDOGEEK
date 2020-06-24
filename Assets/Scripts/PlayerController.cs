using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int hitPoints = 3;
    public int score = 0;
    private new Rigidbody2D rigidbody;
    private Animator playerAnimation;
    private Animation playerAnimation2;
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            playerAnimation.SetTrigger("");
        }
        //Obracanie postaci w przypadku ataku w lewą/prawą stronę
        
        //if (/*left side is clicked*/)
        //{
         //   transform.localScale = new Vector2(1,1);
        //}
        //if (/*right side is clicked*/)
        //{
        //    transform.localScale = new Vector2(-1, 1);
        //}
        //KeyCode key = Ger;
        //isClicked = Input.GetKeyDown("LeftArrow");
        //playerAnimation.SetBool("OnClick", isClicked);

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (playerAnimation.tag == "StandingAnimation")
        //{
            if (hitPoints == 3 || hitPoints == 2)
            {
                //playerAnimation.tag = "GettingHitAnimation";
                //playerAnimation.Play(playerAnimation.tag == "GettingHitAnimation"));
                playerAnimation.SetTrigger("GettingHit");
                Debug.Log("Getting hit, HP decreases...");
                hitPoints--;
                Debug.Log("HP: " + hitPoints);
                playerAnimation.SetTrigger("HasGotHit");
            }
            else if (hitPoints == 1)
            {
                playerAnimation.SetTrigger("GettingLastHit");
                Debug.Log("Getting hit, HP decreases...");
                hitPoints--;
                Debug.Log("HP: " + hitPoints);
                playerAnimation.SetTrigger("HasBeenKilled");
                gameLevelManager.Respawn();
            }

        //}
        /*
        else
        {
            Debug.Log("Your score increases.");
            score++;
            Debug.Log("Score: " + score);
        }
        */
    }

}
