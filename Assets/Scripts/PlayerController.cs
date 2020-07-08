using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimation;
    public int button;
    public int hitPoints = 3;
    private int idAttack = 1;
    private bool facingRight = true;
    // Start is called before the first frame update


    private void SwapAnimation()
    {
        Vector3 local = transform.localScale;
        local.x = Mathf.Abs(local.x) * ((facingRight) ? 1 : -1);
        transform.localScale = local;
    }
    void Start()
    {
        playerAnimation = GetComponent<Animator>();

    }



    // Update is called once per frame
    void Update()
    {
        playerAnimation.SetInteger("IdAttack", idAttack);
        if (Input.GetButtonDown("Fire1"))
        {
            playerAnimation.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (facingRight)
            {
                facingRight = false;
                SwapAnimation();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!facingRight)
            {
                facingRight = true;
                SwapAnimation();
            }
        }








        /*
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
            */
    }
}
