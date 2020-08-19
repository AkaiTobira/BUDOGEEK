using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public static LevelMenu levelMenu;
    public GameObject[] levelButtons;
    public int chosenLevel;
    public bool? isLevelChosen = false;
    void Awake()
    {
        levelMenu = this;
        DontDestroyOnLoad(transform.gameObject);
    }
    public void ChangeLevelOnClick(int level)
    {
        chosenLevel = level;
        isLevelChosen = true;
        StartCoroutine(PlayChosenLevel());
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }

    IEnumerator PlayChosenLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
