using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public static LevelMenu levelMenu;
    public GameObject[] levelButtons;
    public LevelManager levelManager;
    public int chosenLevel;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        levelMenu = this;
        DontDestroyOnLoad(transform.gameObject);
    }
    public void ChangeLevelOnClick(int level)
    {
        chosenLevel = level;
        StartCoroutine(PlayChosenLevel());
    }

    IEnumerator PlayChosenLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
