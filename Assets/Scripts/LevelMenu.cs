using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] levelButtons;
    public int chosenLevel;
    public bool isLevelChosen = false;
    /*
    public GameObject scrollBar;
    float scrollPosition = 0;
    float[] position;
    public HorizontalLayoutGroup horizontalLayoutGroup;
    */
    void Start()
    {
        SavePlayerProgress();
        FillButtonsText();
        UnlockButtons();
    }
    /*
    void Update()
    {
        horizontalLayoutGroup.padding.left = (Screen.currentResolution.width - 200) / 2;
        horizontalLayoutGroup.padding.right = (Screen.currentResolution.width - 200) / 2;
        StickToButtonDuringSwiping();
    }*/
    /*
    public void LockButtons()
    {
        foreach (Button button in levelButtons)
        {
            button.interactable = false;
        }
    }
    */
    public void FillButtonsText()
    {
        for (int i = 1; i < levelButtons.Length; i++)
        {
            Text text = levelButtons[i].GetComponentInChildren<Text>();
            text.text = $"Poziom {i}:\n{PlayerPrefs.GetInt($"HighScore{i-1}")} / {PlayerPrefs.GetInt($"MaxScore{i-1}")}";
        }
    }
    public void UnlockButtons()
    {
        for (int i = 1; i < levelButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt($"HighScore{i-1}") >= PlayerPrefs.GetInt($"MaxScore{i-1}"))
            {
                levelButtons[i].interactable = true;
                Text text = levelButtons[i].GetComponentInChildren<Text>();
                text.text = $"Poziom {i}";
            }
        }
    }
    public void SavePlayerProgress()
    {
        for (int i = 0; i < 7; i++)
        {
            //if (PlayerPrefs.GetInt($"Score{i}") >= PlayerPrefs.GetInt($"MaxScore{i}"))
            if (PlayerPrefs.GetInt($"Score{i}") > PlayerPrefs.GetInt($"HighScore{i}"))
                PlayerPrefs.SetInt($"HighScore{i}", PlayerPrefs.GetInt($"Score{i}"));
        }

    }
    public void ChangeLevelOnClick(int level)
    {
        chosenLevel = level;
        isLevelChosen = true;
        PlayerPrefs.SetInt("CurrentLevel", level);
        StartCoroutine(PlayChosenLevel());
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }

    IEnumerator PlayChosenLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /*
    public void StickToButtonDuringSwiping()//Update
    {
        position = new float[transform.childCount];
        float distance = 1f / (position.Length - 1f);
        for (int i = 0; i < position.Length; i++)
            position[i] = distance * i;
        if (Input.GetMouseButton(0))
            scrollPosition = scrollBar.GetComponent<Scrollbar>().value;
        else
            for (int i = 0; i < position.Length; i++)
                if (scrollPosition < position[i] + (distance / 2) && scrollPosition > position[i] - (distance / 2))
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, position[i], 0.1f);
        
        //Change Buttons' size during swiping
        for (int i = 0; i < position.Length; i++)
            if (scrollPosition < position[i] + (distance / 2) && scrollPosition > position[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < position.Length; j++)
                    if (j != i)
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.75f, 0.75f), 0.1f);
            }
                    
    }
    */
}
