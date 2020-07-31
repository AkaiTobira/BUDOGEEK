using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int[] totalScores;
    public int indexOfAchievedBelt;
    public PlayerData (Player player)
    {
        indexOfAchievedBelt = player.indexOfAchievedBelt;
        totalScores = new int[7];
        totalScores[player.levelManager.currentLevel] = player.playerController.scorePoints;
    }

}
