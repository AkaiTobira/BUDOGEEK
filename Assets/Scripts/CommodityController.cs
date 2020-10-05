using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommodityController : MonoBehaviour
{
    public string nameOfCommodity;
    public Button useButton;
    public Button buyButton;
    public StoreSystem storeSystem;
    public void SwitchBuyButtonToUseButton()
    {
        buyButton.GetComponent<GameObject>().SetActive(false);
        useButton.GetComponent<GameObject>().SetActive(true);
    }
    public void Buy(int price)
    {
        if (PlayerPrefs.GetInt("Currency") >= price)
        {
            PlayerPrefs.SetInt("Currency", PlayerPrefs.GetInt("Currency") - price);
            PlayerPrefs.SetString(nameOfCommodity, "Bought");
            SwitchBuyButtonToUseButton();
            storeSystem.ResetCurrency();
        }
    }
    public void Use()
    {
        if (PlayerPrefs.GetString(nameOfCommodity) == "Bought")
        {
            storeSystem.SetOthersInteractableToTrue();
            storeSystem.SetOthersTextComponent();
            useButton.GetComponentInChildren<Text>().text = "Użyto";
            useButton.GetComponentInChildren<Text>().fontSize = 47;
            useButton.interactable = false;
        }
    }
}
