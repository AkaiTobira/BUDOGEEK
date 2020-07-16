using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]public Transform m_transform;
    public Animator playerAnimation;
    public int hitPoints;
    public int scorePoints;
    public int idTechnique;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();

        //change the below two lines to instruction which swap the first technique depending on playing scene
        idTechnique = 1;
        hitPoints = 3;
        playerAnimation.SetInteger("idTechnique", idTechnique);
    }

    private void SwapAnimation()
    {
        Vector3 local = transform.localScale;
        local.x = Mathf.Abs(local.x) * ((facingRight) ? 1 : -1);
        transform.localScale = local;
    }

    public void ChangeTechniqueOnClick(int idTech)
    {
        idTechnique = idTech;
        playerAnimation.SetInteger("idTechnique", idTechnique);
    }
    /*
    public void GettingHit()
    {
        if (playerAnimation.GetInteger("hitPoints") <= 3 && playerAnimation.GetInteger("hitPoints") > 0)
        {
            playerAnimation.SetTrigger("gettingHit");
            hitPoints--;
        }
        if (playerAnimation.GetInteger("hitPoints") == 0)
        {
            playerAnimation.SetTrigger("losing");
            //respawn/reset
        }
    }
    */
    public void GettingHit()
    {
        if (hitPoints > 0)
        {
            playerAnimation.SetTrigger("gettingHit");
            hitPoints--;
        }
        else
        {
            playerAnimation.SetTrigger("losing");
            //respawn/reset
        }
    }
    public void GettingScorePoint()
    {
        scorePoints++;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (true/*if playing anim is standing*/)
            GettingHit();
        if (true/*is playing other anim*/)
            GettingScorePoint();
    }


    // Update is called once per frame
    void Update()
    {
        m_transform.position += new Vector3(0, Time.deltaTime, 0);
        Debug.Log(playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("standing"));
        //Control Options
        if (Input.GetButtonDown("Fire1"))
        {
            //if do not click any button
            playerAnimation.SetTrigger("technique");
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

        //Combat
        if (true)
        {

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
