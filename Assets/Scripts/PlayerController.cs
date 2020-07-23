using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]public Transform m_transform;
    public Animator playerAnimation;
    private new Rigidbody2D rigidbody;
    public int hitPoints;
    public int scorePoints;
    public int idTechnique;//?
    private bool facingRight = true;
    public Text scoreText;
    public HealthSystem health;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        hitPoints = 2;
        scorePoints = 0;
        //ChangeCurrentTechniqueDueToCurrentScene();
    }
    // Update is called once per frame
    void Update()
    {
        InputControllers();
        //m_transform.position += new Vector3(0, Time.deltaTime, 0);
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
    public void GettingHit()
    {
        if (hitPoints > 0)
        {
            playerAnimation.SetTrigger("gettingHit");
            health.ChangeHealthStatus(hitPoints);
            hitPoints--;
        }
        else
        {
            playerAnimation.SetTrigger("losing");
            health.ChangeHealthStatus(0);
            //respawn/reset
        }
    }
    public void GettingScorePoint()
    {
        scorePoints++;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("standing") ||
            playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("getting_hit") ||
            playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("losing"))
            GettingHit();
        else
            GettingScorePoint();
    }

    public void InputControllers()
    {
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
    }
    /*
    void ChangeCurrentTechniqueDueToCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "1")
            playerAnimation.SetInteger("idTechnique", 1);
        else if (sceneName == "2")
            playerAnimation.SetInteger("idTechnique", 5);
        else if (sceneName == "3")
            playerAnimation.SetInteger("idTechnique", 9);
        else if (sceneName == "4")
            playerAnimation.SetInteger("idTechnique", 13);
    }
    */
}
