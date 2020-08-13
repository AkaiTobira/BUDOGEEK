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
    public bool clickedButton = false;
    public bool isReady = true;
    private const float TIME_OF_REST = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        //techniqueButtons = transform.parent.Find("")<TechniqueButtonsController>();
        //defeatMenu = transform.parent.Find("DefeatMenu").GetComponent<DefeatedMenu>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        hitPoints = 2;
        scorePoints = FindObjectOfType<ScoreSystem>().score;
        jenCoins = 0;
    }
    // Update is called once per frame
    void Update()
    {
        scorePoints = FindObjectOfType<ScoreSystem>().score;
        InputControllers();
        ChangeLayerDefaultWeight();
    }
    public void ChangeLayerDefaultWeight()
    {
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
        if (isReady)
        {
            idTechnique = idTech;
            playerAnimation.SetInteger("idTechnique", idTechnique);
            playerAnimation.SetTrigger("technique");
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

            isReady = false;
            StartCoroutine(RestAWhile(TIME_OF_REST));
        }
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
            StartCoroutine(WaitToEndOfAnimation());
            //respawn/reset
        }
    }
    IEnumerator WaitToEndOfAnimation()
    {
        defeatMenu.scorePoints = scorePoints;
        yield return new WaitForSeconds(1f);
        defeatMenu.PauseGameIfPlayerIsDefeted();
    }
    public void GettingScorePoint()
    {
        scorePoints++;
    }
    public void GettingJenCoin()
    {
        jenCoins++;
    }
    private bool IsInvalidState()
    {
        return playerAnimation.GetCurrentAnimatorStateInfo(levelManager.currentLevel).IsName("standing_white") ||
            playerAnimation.GetCurrentAnimatorStateInfo(levelManager.currentLevel).IsName("standing_yellow") ||
            playerAnimation.GetCurrentAnimatorStateInfo(levelManager.currentLevel).IsName("standing_orange") ||
            playerAnimation.GetCurrentAnimatorStateInfo(levelManager.currentLevel).IsName("standing_green") ||
            playerAnimation.GetCurrentAnimatorStateInfo(levelManager.currentLevel).IsName("standing_blue") ||
            playerAnimation.GetCurrentAnimatorStateInfo(levelManager.currentLevel).IsName("standing_brown") ||
            playerAnimation.GetCurrentAnimatorStateInfo(levelManager.currentLevel).IsName("standing_black");
    }
    private bool IsValidDirection(Collider2D collision)
    {
        //if (IsInvalidState())
        //{
            float posX = collision.GetComponent<Transform>().position.x;
            if (posX > 0 && facingRight)
                return true;
            if (posX < 0 && !facingRight)
                return true;
        //}
        return false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsInvalidState() || !IsValidDirection(collision) || !TechniqueMatcher.CheckIfTechniqueIsEffective(collision.tag, idTechnique) || isReady)
        {
            GettingHit();
            isReady = false;
            StartCoroutine(RestAWhile(TIME_OF_REST));
            //freeze for a while
            //StartCoroutine(WaitAWhile());
            //Time.timeScale = 0f;
            //StartCoroutine(WaitAWhile());
            //Time.timeScale = 1f;
        }
        else
        {
            FindObjectOfType<ScoreSystem>().AddToScore(1);
            FindObjectOfType<DiplomasController>().ShowDiplomaIfGainMaxScoreOfCurrentLevel();
        }

    }
    IEnumerator RestAWhile(float delay)
    {
        yield return new WaitForSeconds(delay);
        isReady = true;
    }
    /*
    public void PressTechniqueButton(params Button[] techniqueButtons)
    {
        foreach (Button button in techniqueButtons)
            if (button.IsActive())
            {
                button.onClick.Invoke();
                var colors = button.colors;
                colors.normalColor = button.colors.selectedColor;
                button.colors = colors;
                clickedButton = true;
                    
            }
    }
    public void RestoreTechniqueButtonNormalColor(params Button[] techniqueButtons)
    {
        foreach (var button in techniqueButtons)
        {
            var colors = button.colors;
            colors.normalColor = button.colors.pressedColor;
            button.colors = colors;
        }

    }*/
    public void InputControllers()
    {
        HandleAndriodInput();
        /*if (Input.GetButtonDown("Fire1"))
        {
            //if do not click any button
            playerAnimation.SetTrigger("technique");
        }*/
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (clickedButton)
            {
                RestoreTechniqueButtonNormalColor(techniqueButtons.secondButtons);
                RestoreTechniqueButtonNormalColor(techniqueButtons.thirdButtons);
                RestoreTechniqueButtonNormalColor(techniqueButtons.fourthButtons);
                clickedButton = false;
            }
            PressTechniqueButton(techniqueButtons.firstButtons);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (clickedButton)
            {
                RestoreTechniqueButtonNormalColor(techniqueButtons.firstButtons);
                RestoreTechniqueButtonNormalColor(techniqueButtons.thirdButtons);
                RestoreTechniqueButtonNormalColor(techniqueButtons.fourthButtons);
                clickedButton = false;
            }
            PressTechniqueButton(techniqueButtons.secondButtons);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (clickedButton)
            {
                RestoreTechniqueButtonNormalColor(techniqueButtons.firstButtons);
                RestoreTechniqueButtonNormalColor(techniqueButtons.secondButtons);
                RestoreTechniqueButtonNormalColor(techniqueButtons.fourthButtons);
                clickedButton = false;
            }
            PressTechniqueButton(techniqueButtons.thirdButtons);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (clickedButton)
            {
                RestoreTechniqueButtonNormalColor(techniqueButtons.firstButtons);
                RestoreTechniqueButtonNormalColor(techniqueButtons.secondButtons);
                RestoreTechniqueButtonNormalColor(techniqueButtons.thirdButtons);
                clickedButton = false;
            }
            PressTechniqueButton(techniqueButtons.fourthButtons);
        }*/
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (facingRight)
            {
                facingRight = false;
                SwapAnimation();
            }
            playerAnimation.SetTrigger("technique");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!facingRight)
            {
                facingRight = true;
                SwapAnimation();
            }
            playerAnimation.SetTrigger("technique");
        }
    }
    private void HandleAndriodInput()//ChangeDirection
    {
        foreach (Touch t in Input.touches)
        {
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
