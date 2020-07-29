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
    public int jenCoins;
    public int idTechnique;//?
    private bool facingRight = true;
    public Text scoreText;
    public HealthSystem health;
    public LevelManager levelManager;
    public TechniqueButtonsController techniqueButtons;
    public DefeatedMenu defeatMenu;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        techniqueButtons = FindObjectOfType<TechniqueButtonsController>();
        defeatMenu = FindObjectOfType<DefeatedMenu>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        hitPoints = 2;
        scorePoints = 0;
        jenCoins = 0;
    }
    // Update is called once per frame
    void Update()
    {
        InputControllers();
        ChangeLayerDefaultWeight();
    }
    public void ChangeLayerDefaultWeight()
    {
        playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Base Layer"), 0f);
        playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 0"), 0f);
        playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 1"), 0f);
        playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 2"), 0f);
        playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 3"), 0f);
        playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 4"), 0f);
        playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 5"), 0f);
        playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 6"), 0f);
        switch (levelManager.currentLevel)
        {
            case 0:
                playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 0"), 1f);
                break;
            case 1:
                playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 1"), 1f);
                break;
            case 2:
                playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 2"), 1f);
                break;
            case 3:
                playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 3"), 1f);
                break;
            case 4:
                playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 4"), 1f);
                break;
            case 5:
                playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 5"), 1f);
                break;
            case 6:
                playerAnimation.SetLayerWeight(playerAnimation.GetLayerIndex("Level 6"), 1f);
                break;
        }
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
        //brown obi
        if (idTechnique == 19 || idTechnique == 20 || idTechnique == 23 || idTechnique == 24 || 
            idTechnique == 28 || idTechnique == 31 || idTechnique == 32 || idTechnique == 34)
            techniqueButtons.ChangeTechniqueButton(techniqueButtons.greenNinjaButtons);
        else if (idTechnique == 21 || idTechnique == 29)
            techniqueButtons.ChangeTechniqueButton(techniqueButtons.blueNinjaButtons);
        else if (idTechnique == 22 || idTechnique == 25 || idTechnique == 26 || idTechnique == 30)
            techniqueButtons.ChangeTechniqueButton(techniqueButtons.purpleNinjaButtons);
        else if (idTechnique == 27 || idTechnique == 33)
            techniqueButtons.ChangeTechniqueButton(techniqueButtons.orangeNinjaButtons);
        //black obi
        else if (idTechnique == 35 || idTechnique == 36 || idTechnique == 39 || idTechnique == 40 || 
            idTechnique == 44 || idTechnique == 47 || idTechnique == 48 || idTechnique == 50)
            techniqueButtons.ChangeTechniqueButton(techniqueButtons.greenNinjaButtons);
        else if (idTechnique == 37 || idTechnique == 45)
            techniqueButtons.ChangeTechniqueButton(techniqueButtons.blueNinjaButtons);
        else if (idTechnique == 38 || idTechnique == 41 || idTechnique == 42 || idTechnique == 46)
            techniqueButtons.ChangeTechniqueButton(techniqueButtons.purpleNinjaButtons);
        else if (idTechnique == 43 || idTechnique == 49)
            techniqueButtons.ChangeTechniqueButton(techniqueButtons.orangeNinjaButtons);
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
            defeatMenu.PauseGameIfPlayerIsDefeted();
            //respawn/reset
        }
    }
    public void GettingScorePoint()
    {
        scorePoints++;
    }
    public void GettingJenCoin()
    {
        jenCoins++;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("standing_white") ||
            playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("standing_yellow") ||
            playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("standing_orange") ||
            playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("standing_green") ||
            playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("standing_blue") ||
            playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("standing_brown") ||
            playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("standing_black"))
        {
            GettingHit();
            //freeze for a while
            //StartCoroutine(WaitAWhile());
            //Time.timeScale = 0f;
            //StartCoroutine(WaitAWhile());
            //Time.timeScale = 1f;
        }
        else
            GettingScorePoint();
    }
    IEnumerator WaitAWhile()
    {
        yield return new WaitForSeconds(0.5f);
    }
    public void InputControllers()
    {
        HandleAndriodInput();
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
    private void HandleAndriodInput()
    {
        foreach (Touch t in Input.touches)
        {
            playerAnimation.SetTrigger("technique");
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(t.position);
            if (touchPosition.x > transform.position.x)
            {
                if (!facingRight)
                {
                    facingRight = true;
                    SwapAnimation();
                }
            }
            else
            {
                if (facingRight)
                {
                    facingRight = false;
                    SwapAnimation();
                }
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
