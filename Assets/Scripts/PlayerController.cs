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
    //public int yenCoins;
    public int idTechnique;//?
    public bool facingRight = true;
    public Text scoreText;
    public HealthSystem health;
    public LevelManager levelManager;
    public TechniqueButtonsController techniqueButtons5;
    public TechniqueButtonsController techniqueButtons6;
    public DefeatedMenu defeatMenu;
    public bool clickedButton = false;
    public bool isReadyToAttack = true;
    public bool isReadyToCollision = true;
    public int highscorePref;
    //public bool doesPlayerGotHit = false;
    private const float TIME_OF_REST = 0.8f;
    public MaxScoreMenu maxScoreMenu;
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
        ChangeLayerDefaultWeight();
    }
    // Update is called once per frame
    void Update()
    {
        scorePoints = FindObjectOfType<ScoreSystem>().score;
        InputControllers();
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
        if (isReadyToAttack)
        {
            idTechnique = idTech;
            playerAnimation.SetInteger("idTechnique", idTechnique);
            playerAnimation.SetTrigger("technique");
            //TechniqueChanger();
            isReadyToAttack = false;
            StartCoroutine(RestAWhile(TIME_OF_REST));
        }
    }
    /*
    public void TechniqueChanger()
    {
        switch (levelManager.currentLevel)
        {
            case 0:
                break;
            case 1:
                ChangeTechniqueButtonsOfLevel1();
                break;
            case 2:
                ChangeTechniqueButtonsOfLevel2();
                break;
            case 3:
                ChangeTechniqueButtonsOfLevel3();
                break;
            case 4:
                ChangeTechniqueButtonsOfLevel4();
                break;
            case 5:
                ChangeTechniqueButtonsOfLevel5();
                break;
            case 6:
                ChangeTechniqueButtonsOfLevel6();
                break;
            default:
                break;
        }
        //zamienić na switch
        if (levelManager.currentLevel == 5)
        {
            //brown obi
            //RIGHT SIDE
            if (idTechnique == 19 || idTechnique == 20 || idTechnique == 23 || idTechnique == 24 ||
            idTechnique == 28 || idTechnique == 31 || idTechnique == 32 || idTechnique == 34)
                techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.greenNinjaButtons_R);
            else if (idTechnique == 21 || idTechnique == 29)
                techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.blueNinjaButtons_R);
            else if (idTechnique == 22 || idTechnique == 25 || idTechnique == 26 || idTechnique == 30)
                techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.purpleNinjaButtons_R);
            else if (idTechnique == 27 || idTechnique == 33)
                techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.orangeNinjaButtons_R);
            //LEFT SIDE
            else if (idTechnique == 190 || idTechnique == 200 || idTechnique == 230 || idTechnique == 240 ||
                idTechnique == 280 || idTechnique == 310 || idTechnique == 320 || idTechnique == 340)
                techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.greenNinjaButtons_L);
            else if (idTechnique == 210 || idTechnique == 290)
                techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.blueNinjaButtons_L);
            else if (idTechnique == 220 || idTechnique == 250 || idTechnique == 260 || idTechnique == 300)
                techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.purpleNinjaButtons_L);
            else if (idTechnique == 270 || idTechnique == 330)
                techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.orangeNinjaButtons_L);
        }
        else if (levelManager.currentLevel == 6)
        {
            //black obi
            //RIGHT SIDE
            if (idTechnique == 35 || idTechnique == 36 || idTechnique == 39 || idTechnique == 40 ||
                idTechnique == 44 || idTechnique == 47 || idTechnique == 48 || idTechnique == 50)
                techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.greenNinjaButtons_R);
            else if (idTechnique == 37 || idTechnique == 45)
                techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.blueNinjaButtons_R);
            else if (idTechnique == 38 || idTechnique == 41 || idTechnique == 42 || idTechnique == 46)
                techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.purpleNinjaButtons_R);
            else if (idTechnique == 43 || idTechnique == 49)
                techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.orangeNinjaButtons_R);
            //LEFT SIDE
            else if (idTechnique == 350 || idTechnique == 360 || idTechnique == 390 || idTechnique == 400 ||
                idTechnique == 440 || idTechnique == 470 || idTechnique == 480 || idTechnique == 500)
                techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.greenNinjaButtons_L);
            else if (idTechnique == 370 || idTechnique == 450)
                techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.blueNinjaButtons_L);
            else if (idTechnique == 380 || idTechnique == 410 || idTechnique == 420 || idTechnique == 460)
                techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.purpleNinjaButtons_L);
            else if (idTechnique == 430 || idTechnique == 490)
                techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.orangeNinjaButtons_L);
        }
    }
    public void ChangeTechniqueButtonsOfLevel1()
    {

    }
    public void ChangeTechniqueButtonsOfLevel2()
    {

    }
    public void ChangeTechniqueButtonsOfLevel3()
    {

    }
    public void ChangeTechniqueButtonsOfLevel4()
    {

    }
    public void ChangeTechniqueButtonsOfLevel5()
    {
        //brown obi
        //RIGHT SIDE
        if (idTechnique == 19 || idTechnique == 20 || idTechnique == 23 || idTechnique == 24 ||
        idTechnique == 28 || idTechnique == 31 || idTechnique == 32 || idTechnique == 34)
            techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.greenNinjaButtons_R);
        else if (idTechnique == 21 || idTechnique == 29)
            techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.blueNinjaButtons_R);
        else if (idTechnique == 22 || idTechnique == 25 || idTechnique == 26 || idTechnique == 30)
            techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.purpleNinjaButtons_R);
        else if (idTechnique == 27 || idTechnique == 33)
            techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.orangeNinjaButtons_R);
        //LEFT SIDE
        else if (idTechnique == 190 || idTechnique == 200 || idTechnique == 230 || idTechnique == 240 ||
            idTechnique == 280 || idTechnique == 310 || idTechnique == 320 || idTechnique == 340)
            techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.greenNinjaButtons_L);
        else if (idTechnique == 210 || idTechnique == 290)
            techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.blueNinjaButtons_L);
        else if (idTechnique == 220 || idTechnique == 250 || idTechnique == 260 || idTechnique == 300)
            techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.purpleNinjaButtons_L);
        else if (idTechnique == 270 || idTechnique == 330)
            techniqueButtons5.ChangeTechniqueButton(techniqueButtons5.orangeNinjaButtons_L);
    }
    public void ChangeTechniqueButtonsOfLevel6()
    {
        //black obi
        //RIGHT SIDE
        if (idTechnique == 35 || idTechnique == 36 || idTechnique == 39 || idTechnique == 40 ||
            idTechnique == 44 || idTechnique == 47 || idTechnique == 48 || idTechnique == 50)
            techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.greenNinjaButtons_R);
        else if (idTechnique == 37 || idTechnique == 45)
            techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.blueNinjaButtons_R);
        else if (idTechnique == 38 || idTechnique == 41 || idTechnique == 42 || idTechnique == 46)
            techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.purpleNinjaButtons_R);
        else if (idTechnique == 43 || idTechnique == 49)
            techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.orangeNinjaButtons_R);
        //LEFT SIDE
        else if (idTechnique == 350 || idTechnique == 360 || idTechnique == 390 || idTechnique == 400 ||
            idTechnique == 440 || idTechnique == 470 || idTechnique == 480 || idTechnique == 500)
            techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.greenNinjaButtons_L);
        else if (idTechnique == 370 || idTechnique == 450)
            techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.blueNinjaButtons_L);
        else if (idTechnique == 380 || idTechnique == 410 || idTechnique == 420 || idTechnique == 460)
            techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.purpleNinjaButtons_L);
        else if (idTechnique == 430 || idTechnique == 490)
            techniqueButtons6.ChangeTechniqueButton(techniqueButtons6.orangeNinjaButtons_L);
    }
    */




    public void GettingHit()
    {
        //if (doesPlayerGotHit)
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
        float posX = collision.GetComponent<Transform>().position.x;
        if (posX > 0 && facingRight)
            return true;
        else if (posX < 0 && !facingRight)
            return true;
        return false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isReadyToCollision)
        {
            //Debug.Log((collision.transform.position - transform.position) * 0.5f + transform.position);
            if (IsInvalidState() || !IsValidDirection(collision) || !TechniqueMatcher.CheckIfTechniqueIsEffective(collision.tag, idTechnique))
            {
                GettingHit();
            }
            else
            {
                FindObjectOfType<ScoreSystem>().AddToScore(1);
                FindObjectOfType<DiplomasController>().ShowDiplomaIfGainMaxScoreOfCurrentLevel();
                //maxScoreMenu.PauseGameIfPlayerAchiveMaxScore();
                FindObjectOfType<YenSystem>().DroppingYenSystem();
                levelManager.EndTutorial();
                levelManager.SaveLevelProgress();
                levelManager.ShowMaxScoreMenu();
            }
            isReadyToCollision = false;
            StartCoroutine(WaitAWhile(TIME_OF_REST));
        }
    }
    IEnumerator RestAWhile(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!isReadyToAttack)
            isReadyToAttack = true;
    }
    IEnumerator WaitAWhile(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!isReadyToCollision)
            isReadyToCollision = true;
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
