using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public GameObject[] ninjasOfLeftSide;
    public GameObject[] ninjasOfRightSide;
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
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfRightSide[4], ninjasOfLeftSide[0],
                                 ninjasOfLeftSide[1], ninjasOfLeftSide[4]);
                break;
            case 1:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfRightSide[2], ninjasOfRightSide[4], 
                                 ninjasOfLeftSide[0], ninjasOfLeftSide[1],
                                 ninjasOfLeftSide[2], ninjasOfLeftSide[4]);
                break;
            case 2:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[2],
                                  ninjasOfRightSide[4], ninjasOfLeftSide[0], 
                                  ninjasOfLeftSide[2], ninjasOfLeftSide[4]);
                break;
            case 3:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfRightSide[2], ninjasOfRightSide[3],
                                 ninjasOfRightSide[4], ninjasOfRightSide[5],
                                 ninjasOfLeftSide[0], ninjasOfLeftSide[1],
                                 ninjasOfLeftSide[2], ninjasOfLeftSide[3],
                                 ninjasOfLeftSide[4], ninjasOfLeftSide[5]);
                break;
            case 4:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[3],
                                 ninjasOfRightSide[4], ninjasOfLeftSide[0], 
                                 ninjasOfLeftSide[3], ninjasOfLeftSide[4]);
                break;
            case 5:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfRightSide[2], ninjasOfRightSide[3],
                                 ninjasOfRightSide[4], ninjasOfRightSide[5],
                                 ninjasOfLeftSide[0], ninjasOfLeftSide[1],
                                 ninjasOfLeftSide[2], ninjasOfLeftSide[3],
                                 ninjasOfLeftSide[4], ninjasOfLeftSide[5]);
                break;
            case 6:
                StartCoroutine(WaitBeforeSpawnNinja(levelManager));
                SpawnRandomNinja(ninjasOfRightSide[0], ninjasOfRightSide[1],
                                 ninjasOfRightSide[2], ninjasOfRightSide[3],
                                 ninjasOfRightSide[4], ninjasOfRightSide[5],
                                 ninjasOfLeftSide[0], ninjasOfLeftSide[1],
                                 ninjasOfLeftSide[2], ninjasOfLeftSide[3],
                                 ninjasOfLeftSide[4], ninjasOfLeftSide[5]);
                break;
        }
    }
    public void SpawnRandomNinja(params GameObject[] tabOfNinjas)
    {
        int tmp = UnityEngine.Random.Range(0, tabOfNinjas.Length + 1);
        if (tabOfNinjas[tmp].name == "pillow_ninja")
        {
            tabOfNinjas[tmp].GetComponent<Animator>().SetTrigger("attack");
            StartCoroutine(ThrowPillow(tabOfNinjas[tmp]));
        }
        else if (tabOfNinjas[tmp].name == "plate_ninja")
        {
            tabOfNinjas[tmp].GetComponent<Animator>().SetTrigger("attack");
            StartCoroutine(ThrowPlate(tabOfNinjas[tmp]));
        }
        else
            tabOfNinjas[tmp].GetComponent<Animator>().SetTrigger("attack");
    }
    IEnumerator ThrowPillow(GameObject ninja)
    {
        yield return new WaitForSeconds(0.25f);
        ninja.GetComponent<Animator>().SetTrigger("throw");
    }
    IEnumerator ThrowPlate(GameObject ninja)
    {
        yield return new WaitForSeconds(0.5f);
        ninja.GetComponent<Animator>().SetTrigger("throw");
    }
    IEnumerator WaitBeforeSpawnNinja(LevelManager lvlManager)
    {
        switch(lvlManager.currentLevel)
        {
            case 0:
                yield return new WaitForSeconds(180);
                break;
            case 1:
                yield return new WaitForSeconds(170);
                break;
            case 2:
                yield return new WaitForSeconds(160);
                break;
            case 3:
                yield return new WaitForSeconds(150);
                break;
            case 4:
                yield return new WaitForSeconds(140);
                break;
            case 5:
                yield return new WaitForSeconds(130);
                break;
            case 6:
                yield return new WaitForSeconds(120);
                break;
        }
    }
}
