using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public GameObject[] ninjasOfLeftSide;
    public GameObject[] ninjasOfRightSide;
    public GameObject pillow;
    public GameObject plate;
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    // Update is called once per frame
    void Update()
    {
        SpawnRandomNinjaDependingOnCurrentLevel();
    }

    public void SpawnRandomNinjaDependingOnCurrentLevel()
    {
        //4 - pillow, 5 - plate
        switch (levelManager.currentLevel)
        {
            case 0:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                break;
            case 1:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                break;
            case 2:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                break;
            case 3:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                break;
            case 4:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                break;
            case 5:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                break;
            case 6:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                break;
        }
    }
    public void SpawnRandomNinja(params GameObject[] tabOfNinjas)
    {
        int tmp = UnityEngine.Random.Range(0, tabOfNinjas.Length);
        if (tabOfNinjas[tmp].name == "pillow_ninja")
        {
            tabOfNinjas[tmp].GetComponent<Animator>().SetTrigger("attack");
            StartCoroutine(ThrowPillow(pillow));
        }
        else if (tabOfNinjas[tmp].name == "plate_ninja")
        {
            tabOfNinjas[tmp].GetComponent<Animator>().SetTrigger("attack");
            StartCoroutine(ThrowPlate(plate));
        }
        else
            tabOfNinjas[tmp].GetComponent<Animator>().SetTrigger("attack");
    }
    IEnumerator ThrowPillow(GameObject pillow)
    {
        yield return new WaitForSeconds(0.25f);
        pillow.GetComponent<Animator>().SetTrigger("throw");
    }
    IEnumerator ThrowPlate(GameObject plate)
    {
        yield return new WaitForSeconds(0.5f);
        plate.GetComponent<Animator>().SetTrigger("throw");
    }
    IEnumerator WaitBeforeSpawnNinja(LevelManager lvlManager)
    {
        switch(lvlManager.currentLevel)
        {
            case 0:
                yield return new WaitForSeconds(4);
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfLeftSide[0], ninjasOfLeftSide[1]);
                break;
            case 1:
                yield return new WaitForSeconds(4);
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfRightSide[2], ninjasOfLeftSide[0],
                                 ninjasOfLeftSide[1], ninjasOfLeftSide[2]);
                break;
            case 2:
                yield return new WaitForSeconds(4);
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[2],
                                  ninjasOfLeftSide[0], ninjasOfLeftSide[2]);
                break;
            case 3:
                yield return new WaitForSeconds(4);
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfRightSide[2], ninjasOfRightSide[3],
                                 ninjasOfLeftSide[0], ninjasOfLeftSide[1],
                                 ninjasOfLeftSide[2], ninjasOfLeftSide[3]);
                break;
            case 4:
                yield return new WaitForSeconds(4);
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[3],
                                 ninjasOfLeftSide[0], ninjasOfLeftSide[3]);
                break;
            case 5:
                yield return new WaitForSeconds(3);
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfRightSide[2], ninjasOfRightSide[3],
                                 ninjasOfLeftSide[0], ninjasOfLeftSide[1],
                                 ninjasOfLeftSide[2], ninjasOfLeftSide[3]);
                break;
            case 6:
                yield return new WaitForSeconds(2);
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfRightSide[2], ninjasOfRightSide[3],
                                 ninjasOfLeftSide[0], ninjasOfLeftSide[1],
                                 ninjasOfLeftSide[2], ninjasOfLeftSide[3]);
                break;
        }
    }
}
