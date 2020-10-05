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
    private float[] TIME_TO_SHOW_EFFECT = { 1f, 1.2f, 1.25f, 1f };
    private float[] SPEED_OF_ANIMATOR = { 0.7f, 0.8f, 0.9f, 1f, 1.05f, 1.1f, 1.15f };
    private float[] SPEED_OF_ANIMATOR_THROWING_OBJECTS = { 1f, 1.05f, 1.1f, 1.15f, 1.2f, 1.25f, 1.3f };
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
    public GameObject[] opponentSounds;
    public GameObject[] brokenSounds;
    public float speedOfNinja = 0f;


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
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        FillEnemyOfLevels();
    }
    void Update()
    {
        timerToSpawnEnemy -= Time.deltaTime;
        if (timerToSpawnEnemy < 0 && levelManager.isGameStarted && !doesAchieveMaxScore)
        {
            SpawnRandomNinjaDependingOnCurrentLevel();
            timerToSpawnEnemy = TIME_SPAWN_DELAY[levelManager.currentLevel].GetRandomDelay();
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
    public void DefineAnimatorSpeed(List<GameObject> tabOfNinjas, int random)
    {
        tabOfNinjas[random].GetComponent<Animator>().speed = SPEED_OF_ANIMATOR[levelManager.currentLevel];
    }
    public void SpawnRandomNinjaDependingOnCurrentLevel()
    {
        List<GameObject> enemies = new List<GameObject>();
        List<GameObject> effects = new List<GameObject>();
        List<GameObject> soundsO = new List<GameObject>();
        List<GameObject> soundsB = new List<GameObject>();
        foreach (int index in enemyOfLevels[levelManager.currentLevel])
        {
            enemies.Add(ninjasOfLeftSide[index]);
            enemies.Add(ninjasOfRightSide[index]);
            effects.Add(effectsOfLeftSide[index]);
            effects.Add(effectsOfRightSide[index]);
            soundsO.Add(opponentSounds[index]);
            soundsO.Add(opponentSounds[index]);
            soundsB.Add(brokenSounds[index]);
            soundsB.Add(brokenSounds[index]);
        }
        SpawnRandomNinja(enemies, effects, soundsO, soundsB);
    }
    public void SpawnRandomNinja(List<GameObject> tabOfNinjas, List<GameObject> tabOfEffects, List<GameObject> tabOfSoundsO, List<GameObject> tabOfSoundsB)
    {
        int tmp = UnityEngine.Random.Range(0, tabOfNinjas.Count);
        float multiplier = SPEED_OF_ANIMATOR[levelManager.currentLevel];
        float multiplierOfTO = SPEED_OF_ANIMATOR_THROWING_OBJECTS[levelManager.currentLevel];
        if (levelManager.tutorialStep == 7)
            StartCoroutine(ShowLayer(0.5f));
        DefineAnimatorSpeed(tabOfNinjas, tmp);
        tabOfNinjas[tmp].GetComponent<Animator>().SetTrigger("attack");
        tabOfSoundsO[tmp].GetComponent<AudioSource>().Play();
        switch (tabOfNinjas[tmp].name)
        {
            case "opponent_pillow":
                StartCoroutine(ThrowObject(pillow[tmp % 2], TIME_TO_THROW_PILLOW / multiplier / multiplierOfTO));
                StartCoroutine(ShowEffectAndPlaySound(tabOfEffects[tmp], (TIME_TO_SHOW_EFFECT[0] / multiplier) + (TIME_TO_THROW_PILLOW / multiplierOfTO)/*, "pillow"*/, tabOfSoundsB[tmp]));
                break;
            case "opponent_plate":
                StartCoroutine(ThrowObject(plate[tmp % 2], TIME_TO_THROW_PLATE / multiplier / multiplierOfTO));
                StartCoroutine(ShowEffectAndPlaySound(tabOfEffects[tmp], (TIME_TO_SHOW_EFFECT[3] / multiplier) + (TIME_TO_THROW_PLATE / multiplierOfTO)/*, "plate"*/, tabOfSoundsB[tmp]));
                break;
            case "opponent_board":
                StartCoroutine(ShowEffectAndPlaySound(tabOfEffects[tmp], TIME_TO_SHOW_EFFECT[1] / multiplier/*, "board"*/, tabOfSoundsB[tmp]));
                break;
            case "opponent_mop":
                StartCoroutine(ShowEffectAndPlaySound(tabOfEffects[tmp], TIME_TO_SHOW_EFFECT[2] / multiplier/*, "mop"*/, tabOfSoundsB[tmp]));
                break;
            default:
                Debug.LogError("Get invalid name of ninja! " + tabOfNinjas[tmp].name);
                break;
        }
    }
    IEnumerator ShowLayer(float time)
    {
        yield return new WaitForSeconds(time);
        levelManager.ShowTutorialLayer7();
    }
    IEnumerator ThrowObject(GameObject obj, float time)
    {
        float multiplier = SPEED_OF_ANIMATOR_THROWING_OBJECTS[levelManager.currentLevel];
        yield return new WaitForSeconds(time);
        obj.GetComponent<Animator>().speed = multiplier;
        obj.GetComponent<Animator>().SetTrigger("attack");
    }
    IEnumerator ShowEffectAndPlaySound(GameObject effect, float time, GameObject sound)
    {
        yield return new WaitForSeconds(time);
        effect.SetActive(true);
        sound.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1/effect.GetComponent<Animator>().speed);
        effect.SetActive(false);
    }
}
