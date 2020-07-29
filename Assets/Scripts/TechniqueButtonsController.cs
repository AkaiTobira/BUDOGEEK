using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechniqueButtonsController : MonoBehaviour
{
    public GameObject[] greenNinjaButtons;
    public GameObject[] blueNinjaButtons;
    public GameObject[] purpleNinjaButtons;
    public GameObject[] orangeNinjaButtons;
    public void ChangeTechniqueButton(GameObject[] techNinjaButtons)
    {
        int tmp = Random.Range(0, techNinjaButtons.Length + 1);
        foreach (var button in techNinjaButtons)
        {
            button.SetActive(false);
        }
        techNinjaButtons[tmp].SetActive(true);
    }
}
