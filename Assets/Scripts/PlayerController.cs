using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimation;
    public int button;
    public int hitPoints = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();

    }



    // Update is called once per frame
    void Update()
    {
        //
        if (Input.GetKeyDown("w"))
        {
            if (playerAnimation.GetCurrentAnimatorStateInfo(0).ToString() == "standing")
            {
                if (hitPoints == 3 || hitPoints == 2)
                {
                    //playerAnimation.tag = "GettingHitAnimation";
                    //playerAnimation.Play(playerAnimation.tag == "GettingHitAnimation"));
                    playerAnimation.SetTrigger("GetHit");
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
                    //playerAnimation.SetTrigger("HasBeenKilled");
                    //gameLevelManager.Respawn();
                }
            }
            playerAnimation.SetTrigger("OnTap");
        }
    }
}
