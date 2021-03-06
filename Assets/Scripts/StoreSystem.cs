﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoreSystem : MonoBehaviour
{
    /*
    private static Dictionary<string, int> kimono = new Dictionary<string, int>();
    private static Dictionary<string, int> belt = new Dictionary<string, int>();
    private static Dictionary<string, int> background = new Dictionary<string, int>();
    public Button[] useButtons;
    public Button[] buyButtonsK;
    public Button[] buyButtonsB;
    public Button[] buyButtonsBG;
    public GameObject[] priceK;
    public GameObject[] priceB;
    public GameObject[] priceBG;
    private static void FillDictionary()
    {
        kimono["basic"] = 0;
        kimono["black"] = 100;
        kimono["golden"] = 200;
        belt["basic"] = 0;
        belt["pink"] = 100;
        belt["master"] = 200;
        background["basic"] = 0;
        background["spring"] = 100;
        background["summer"] = 100;
        background["autumn"] = 100;
        background["winter"] = 100;
    }
    static StoreSystem()
    {
        FillDictionary();
    }
    public void CheckStoreSupplies()
    {
        GivePossibilityOfBuying(1, 100, buyButtonsK[0]);
        GivePossibilityOfBuying(2, 100, buyButtonsK[1]);

        GivePossibilityOfBuying(3, 70, buyButtonsB[0]);
        GivePossibilityOfBuying(6, 70, buyButtonsB[1]);

        GivePossibilityOfBuying(1, 50, buyButtonsBG[0]);
        GivePossibilityOfBuying(2, 50, buyButtonsBG[1]);
        GivePossibilityOfBuying(3, 50, buyButtonsBG[2]);
        GivePossibilityOfBuying(4, 50, buyButtonsBG[3]);
    }
    */
    public Button[] useButtons;
    public Button[] buyButtons;
    public GameObject yen;
    public GameObject[] commodities;
    public GameObject[] requirements;
    public string typeOfItem;
    public int level;

    public void DeactivateOtherCommodities()
    {
        foreach (GameObject item in commodities)
        {
            item.SetActive(false);
        }
    }
    public void SetOthersTextComponent()
    {
        foreach (Button item in useButtons)
        {
            item.GetComponentInChildren<Text>().text = "Użyj";
            item.GetComponentInChildren<Text>().fontSize = 60;
        }
    }
    public void SetOthersInteractableToTrue()
    {
        foreach (Button item in useButtons)
            item.interactable = true;
    }
    public void GivePossibilityOfBuyingAndHideRequirement(int level, int score, Button buyButton, GameObject requirement)
    {
        if (PlayerPrefs.GetInt($"HighScore{level}") >= score)
        {
            buyButton.interactable = true;
            requirement.SetActive(false);
        }
    }
    public void GivePossibilityOfBuyingAndHideRequirement2(int level, int score, Button buyButton, GameObject requirement)
    {
        switch (typeOfItem)
        {
            case "kimono":
            case "background":
                if (PlayerPrefs.GetInt($"HighScore{level}") >= score && PlayerPrefs.GetInt($"HighScore{level + 1}") >= score)
                {
                    buyButton.interactable = true;
                    requirement.SetActive(false);
                }
                break;
            case "belt":
                if (PlayerPrefs.GetInt($"HighScore{level}") >= score)
                {
                    buyButton.interactable = true;
                    requirement.SetActive(false);
                }
                break;
            default:
                break; 
        }
    }
    public void ResetCurrency()
    {
        yen.SetActive(false);
        StartCoroutine(WaitAWhile());
    }
    IEnumerator WaitAWhile()
    {
        yield return new WaitForSeconds(0.01f);
        yen.SetActive(true);
    }
    void Start()
    {
        switch (typeOfItem)
        {
            case "background":
                GivePossibilityOfBuyingAndHideRequirement2(level, 50, buyButtons[0], requirements[0]);
                break;
            case "kimono":
                GivePossibilityOfBuyingAndHideRequirement2(level, 75, buyButtons[0], requirements[0]);
                break;
            case "belt":
                GivePossibilityOfBuyingAndHideRequirement2(level, 100, buyButtons[0], requirements[0]);
                break;
            default:
                break;
        }
    }
    void Update()
    {

    }
}
