using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    private Dictionary<int, List<int>> enemyOfLevels;
    public GameObject opponents;
    public GameObject[] ninjasOfLeftSide;
    public GameObject[] ninjasOfRightSide;
    public GameObject[] pillow;
    public GameObject[] plate;
    public LevelManager levelManager;
    private const float TIME_TO_THROW_PILLOW = 0.25f;
    private const float TIME_TO_THROW_PLATE = 0.5f;
    private float timerToSpawnEnemy = 0;
    private float[] TIME_SPAWN_DELAY = { 3f, 3f, 3f, 3f, 2.75f, 2.5f, 2.25f };
    public bool IsAchieveMaxScore = false;

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
        if (timerToSpawnEnemy < 0 && !IsAchieveMaxScore && levelManager.IsGameStarted)
        {
            SpawnRandomNinjaDependingOnCurrentLevel();
            timerToSpawnEnemy = TIME_SPAWN_DELAY[levelManager.currentLevel];
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
    public void SpawnRandomNinjaDependingOnCurrentLevel()
    {
        List<GameObject> enemies = new List<GameObject>();
        foreach (int index in enemyOfLevels[levelManager.currentLevel])
        {
            enemies.Add(ninjasOfLeftSide[index]);
            enemies.Add(ninjasOfRightSide[index]);
        }
        SpawnRandomNinja(enemies);
    }
    public void SpawnRandomNinja(List<GameObject> tabOfNinjas)
    {
        int tmp = UnityEngine.Random.Range(0, tabOfNinjas.Count);
        tabOfNinjas[tmp].GetComponent<Animator>().SetTrigger("attack");
        switch (tabOfNinjas[tmp].name)
        {
            case "opponent_pillow":
                StartCoroutine(ThrowObject(pillow[tmp % 2], TIME_TO_THROW_PILLOW));
                break;
            case "opponent_plate":
                StartCoroutine(ThrowObject(plate[tmp % 2], TIME_TO_THROW_PLATE));
                break;
            case "opponent_board":
            case "opponent_mop":
                break;
            default:
                Debug.LogError("Get invalid name of ninja! " + tabOfNinjas[tmp].name);
                break;
        }
    }
    IEnumerator ThrowObject(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.GetComponent<Animator>().SetTrigger("attack");
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
