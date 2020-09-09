using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechniqueButtonsController : MonoBehaviour
{
    public GameObject[] greenNinjaButtons_L;
    public GameObject[] blueNinjaButtons_L;
    public GameObject[] purpleNinjaButtons_L;
    public GameObject[] orangeNinjaButtons_L;
    public GameObject[] greenNinjaButtons_R;
    public GameObject[] blueNinjaButtons_R;
    public GameObject[] purpleNinjaButtons_R;
    public GameObject[] orangeNinjaButtons_R;
    public Button[] firstButtons;
    public Button[] secondButtons;
    public Button[] thirdButtons;
    public Button[] fourthButtons;


    public GameObject[] namesOfTechniques;
    public PlayerController playerController;
    public LevelManager levelManager;
    public GameObject[] LeftTechButtons;
    public GameObject[] RightTechButtons;


    public void ChangeTechniqueButton(GameObject[] techNinjaButtons)
    {
        int tmp = Random.Range(0, techNinjaButtons.Length);
        foreach (var button in techNinjaButtons)
        {
            button.SetActive(false);
        }
        techNinjaButtons[tmp].SetActive(true);
    }
    public void ChangeRightButton(string tag)
    {
        StartCoroutine(ChangeButton(tag, RightTechButtons));
    }
    public void ChangeLeftButton(string tag)
    {
        StartCoroutine(ChangeButton(tag, LeftTechButtons));
    }
    IEnumerator ChangeButton(string tag, GameObject[] buttons)
    {
        yield return new WaitForSeconds(0.8f);
        if (ButtonChanger.CheckWhetherButtonShouldBeSwaped(levelManager.currentLevel, tag, playerController.idTechnique))
        {
            buttons[playerController.idTechnique - 1].SetActive(false);
            buttons[ButtonChanger.SwapButton(levelManager.currentLevel, tag, playerController.idTechnique) - 1].SetActive(true);
        }
    }
    public void ChangeButtonColor(Button button)
    {
        //var colors = button.colors;
        button.interactable = false;
        //colors.normalColor = button.colors.pressedColor;
        //button.colors = colors;
        StartCoroutine(RestoreButtonColor(button));
    }
    IEnumerator RestoreButtonColor(Button button)
    {
        yield return new WaitForSeconds(0.8f);
        //var colors = button.colors;
        //colors.normalColor = button.colors.selectedColor;
        //button.colors = colors;
        button.interactable = true;
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
