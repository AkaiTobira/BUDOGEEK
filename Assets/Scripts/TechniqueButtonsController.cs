using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechniqueButtonsController : MonoBehaviour
{
    public GameObject[] greenNinjaButtons;
    public GameObject[] blueNinjaButtons;
    public GameObject[] purpleNinjaButtons;
    public GameObject[] orangeNinjaButtons;
    public Button[] firstButtons;
    public Button[] secondButtons;
    public Button[] thirdButtons;
    public Button[] fourthButtons;
    public GameObject[] namesOfTechniques;
    public void ChangeTechniqueButton(GameObject[] techNinjaButtons)
    {
        int tmp = Random.Range(0, techNinjaButtons.Length);
        foreach (var button in techNinjaButtons)
        {
            button.SetActive(false);
        }
        techNinjaButtons[tmp].SetActive(true);
    }
    public void ShowNameOfTechnique(int index)
    {
        HideOtherNames();
        namesOfTechniques[index].SetActive(true);
    }
    public void HideOtherNames()
    {
        foreach (GameObject name in namesOfTechniques)
            name.SetActive(false);
    }
}
