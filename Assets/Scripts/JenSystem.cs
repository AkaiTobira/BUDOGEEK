using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JenSystem : MonoBehaviour
{
    public PlayerController player;
    public int jen;
    public Text jenText;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        jen = player.jenCoins;
        jenText.text = "" + jen;

    }
    void Update()
    {
        jen = player.jenCoins;
        jenText.text = "" + jen;
    }
}
