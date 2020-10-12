using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommodityController : MonoBehaviour
{
    public string nameOfCommodity;
    public string typeOfCommodity;
    public string isBought;
    public string isInUse;
    public GameObject commodity;
    public GameObject useButton;
    public GameObject buyButton;
    public StoreSystem storeSystem;
    public void SwitchBuyButtonToUseButton()
    {
        buyButton.SetActive(false);
        useButton.SetActive(true);
    }
    public void Buy(int price)
    {
        if (PlayerPrefs.GetInt("Currency") >= price)
        {
            PlayerPrefs.SetInt("Currency", PlayerPrefs.GetInt("Currency") - price);
            PlayerPrefs.SetString(isBought, "Bought");
            SwitchBuyButtonToUseButton();
            storeSystem.ResetCurrency();
        }
    }
    public void Use()
    {
        if (PlayerPrefs.GetString(isBought) == "Bought")
        {
            storeSystem.SetOthersInteractableToTrue();
            storeSystem.SetOthersTextComponent();
            useButton.GetComponentInChildren<Text>().text = "Użyto";
            useButton.GetComponentInChildren<Text>().fontSize = 47;
            useButton.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetString(typeOfCommodity, nameOfCommodity);
            SetUseItem();
        }
    }
    void Start()
    {
        if (PlayerPrefs.GetString(isBought) == "Bought")
            SwitchBuyButtonToUseButton();
        switch (typeOfCommodity)
        {
            case "kimono":
                if (PlayerPrefs.GetString("kimonoInUse") == nameOfCommodity)
                    Use();
                break;
            case "background":
                if (PlayerPrefs.GetString("backgroundInUse") == nameOfCommodity)
                    Use();
                break;
            case "belt":
                if (PlayerPrefs.GetString("beltInUse") == nameOfCommodity)
                    Use();
                break;
            default:
                break;
        }
    }
    public void SetUseItem()
    {
        switch (typeOfCommodity)
        {
            case "kimono":
                PlayerPrefs.SetString("kimonoInUse", nameOfCommodity);
                break;
            case "background":
                PlayerPrefs.SetString("backgroundInUse", nameOfCommodity);
                break;
            case "belt":
                PlayerPrefs.SetString("beltInUse", nameOfCommodity);
                break;
            default:
                break;
        }
    }
}
