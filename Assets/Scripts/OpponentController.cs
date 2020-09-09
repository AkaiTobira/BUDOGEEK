using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class OpponentController : MonoBehaviour
{
    private Dictionary<int, List<int>> enemyOfLevels;
    public GameObject opponents;
    public GameObject[] ninjasOfLeftSide;
    public GameObject[] ninjasOfRightSide;
    public GameObject[] pillow;
    public GameObject[] plate;
    public GameObject[] effectsOfLeftSide;
    public GameObject[] effectsOfRightSide;
    public LevelManager levelManager;
    private const float TIME_TO_THROW_PILLOW = 0.66f;
    private const float TIME_TO_THROW_PLATE = 0.5f;
    private const float TIME_TO_SHOW_EFFECT_1 = 1.6f;
    private const float TIME_TO_SHOW_EFFECT_2 = 1.2f;
    private const float TIME_TO_SHOW_EFFECT_3 = 1.25f;
    private const float TIME_TO_SHOW_EFFECT_4 = 0.9f;
    private float timerToSpawnEnemy = 0;
    private SpawnDelayRanges[] TIME_SPAWN_DELAY = { 
        new SpawnDelayRanges(3f, 5f), 
        new SpawnDelayRanges(2.7f, 4f), 
        new SpawnDelayRanges(2.5f, 3f), 
        new SpawnDelayRanges(2.3f, 3.5f), 
        new SpawnDelayRanges(2f, 2.75f), 
        new SpawnDelayRanges(1.8f, 2.5f), 
        new SpawnDelayRanges(1.5f, 2.25f) 
    };
    public bool doesAchieveMaxScore = false;

    private struct SpawnDelayRanges
    {
        public float _min, _max;
        public SpawnDelayRanges(float min, float max)
        {
            _min = min; _max = max;
        }
        public float GetRandomDelay()
        {
            return UnityEngine.Random.Range(_min,_max);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        FillEnemyOfLevels();
    }
    // Update is called once per frame
    void Update()
    {
        //if (FindObjectOfType<ScoreSystem>().score != levelManager.maxScores[levelManager.currentLevel])
        timerToSpawnEnemy -= Time.deltaTime; 
        if (timerToSpawnEnemy < 0 && levelManager.isGameStarted && !doesAchieveMaxScore)
        {
            SpawnRandomNinjaDependingOnCurrentLevel();
            timerToSpawnEnemy = TIME_SPAWN_DELAY[levelManager.currentLevel].GetRandomDelay();
            //Debug.Log(timerToSpawnEnemy);
        }
    }
    private void FillEnemyOfLevels()
    {
        enemyOfLevels = new Dictionary<int, List<int>>();
        enemyOfLevels[0] = new List<int>() { 0, 1 };
        enemyOfLevels[1] = new List<int>() { 0, 1, 2 };
        enemyOfLevels[2] = new List<int>() { 0, 2 };
        enemyOfLevels[3] = new List<int>() { 0, 1, 2, 3 };
        enemyOfLevels[4] = new List<int>() { 0, 3 };
        enemyOfLevels[5] = new List<int>() { 0, 1, 2, 3 };
        enemyOfLevels[6] = new List<int>() { 0, 1, 2, 3 };
    }
    public void DefineDelayOfSpawning()
    {

    }
    public void SpawnRandomNinjaDependingOnCurrentLevel()
    {
        List<GameObject> enemies = new List<GameObject>();
        List<GameObject> effects = new List<GameObject>();
        foreach (int index in enemyOfLevels[levelManager.currentLevel])
        {
            enemies.Add(ninjasOfLeftSide[index]);
            enemies.Add(ninjasOfRightSide[index]);
            effects.Add(effectsOfLeftSide[index]);
            effects.Add(effectsOfRightSide[index]);
        }
        SpawnRandomNinja(enemies, effects);
    }
    public void SpawnRandomNinja(List<GameObject> tabOfNinjas, List<GameObject> tabOfEffects)
    {
        int tmp = UnityEngine.Random.Range(0, tabOfNinjas.Count);
        tabOfNinjas[tmp].GetComponent<Animator>().SetTrigger("attack");
        switch (tabOfNinjas[tmp].name)
        {
            case "opponent_pillow":
                StartCoroutine(ThrowObject(pillow[tmp % 2], TIME_TO_THROW_PILLOW));
                StartCoroutine(ShowEffect(tabOfEffects[tmp], TIME_TO_SHOW_EFFECT_1));
                break;
            case "opponent_plate":
                StartCoroutine(ThrowObject(plate[tmp % 2], TIME_TO_THROW_PLATE));
                StartCoroutine(ShowEffect(tabOfEffects[tmp], TIME_TO_SHOW_EFFECT_2));
                break;
            case "opponent_board":
                StartCoroutine(ShowEffect(tabOfEffects[tmp], TIME_TO_SHOW_EFFECT_3));
                break;
            case "opponent_mop":
                StartCoroutine(ShowEffect(tabOfEffects[tmp], TIME_TO_SHOW_EFFECT_4));
                break;
            default:
                Debug.LogError("Get invalid name of ninja! " + tabOfNinjas[tmp].name);
                break;
        }
        if (levelManager.tutorialStep == 7)
            StartCoroutine(ShowLayer(0.5f));
    }
    IEnumerator ShowLayer(float time)
    {
        yield return new WaitForSeconds(time);
        levelManager.ShowTutorialLayer7();
    }
    IEnumerator ThrowObject(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.GetComponent<Animator>().SetTrigger("attack");
    }
    IEnumerator ShowEffect(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(true);
        obj.GetComponent<Animator>().SetTrigger("effect");
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
    }
    /*
    public void ResetOpponents()
    {
        if (!opponents.activeInHierarchy)
        {
            ninjasOfRightSide[0].GetComponent<Animator>().;
        }
    }
    public void ResetOpponent(GameObject[] ninjas)
    {
        foreach (GameObject ninja in ninjasOfLeftSide)
            ninja.GetComponent<Animator>().
    }*/
}
