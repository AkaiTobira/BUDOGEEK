using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ButtonChanger
{
    private static Dictionary<int, Dictionary<string, List<int>>> buttons = new Dictionary<int, Dictionary<string, List<int>>>();
    private static void FillDictionary()
    {
        buttons[0] = new Dictionary<string, List<int>>();
        buttons[0]["Enemy1"] = new List<int>() { 1 };
        buttons[0]["Enemy2"] = new List<int>() { 2 };

        buttons[1] = new Dictionary<string, List<int>>();
        buttons[1]["Enemy1"] = new List<int>() { 3, 4 };
        buttons[1]["Enemy2"] = new List<int>() { 5 };
        buttons[1]["Enemy3"] = new List<int>() { 6 };

        buttons[2] = new Dictionary<string, List<int>>();
        buttons[2]["Enemy1"] = new List<int>() { 7, 8 };
        buttons[2]["Enemy3"] = new List<int>() { 9, 10 };

        buttons[3] = new Dictionary<string, List<int>>();
        buttons[3]["Enemy1"] = new List<int>() { 12 };
        buttons[3]["Enemy2"] = new List<int>() { 13 };
        buttons[3]["Enemy3"] = new List<int>() { 14 };
        buttons[3]["Enemy4"] = new List<int>() { 11 };

        buttons[4] = new Dictionary<string, List<int>>();
        buttons[4]["Enemy1"] = new List<int>() { 15, 16, 18 };
        buttons[4]["Enemy4"] = new List<int>() { 17 };

        buttons[5] = new Dictionary<string, List<int>>();
        buttons[5]["Enemy1"] = new List<int>() { 19, 20, 23, 24, 28, 31, 32, 34 };
        buttons[5]["Enemy2"] = new List<int>() { 21, 29 };
        buttons[5]["Enemy3"] = new List<int>() { 22, 25, 26, 30 };
        buttons[5]["Enemy4"] = new List<int>() { 27, 33 };

        buttons[6] = new Dictionary<string, List<int>>();
        buttons[6]["Enemy1"] = new List<int>() { 35, 36, 39, 40, 44, 47, 48, 50 };
        buttons[6]["Enemy2"] = new List<int>() { 37, 45 };
        buttons[6]["Enemy3"] = new List<int>() { 38, 41, 42, 46 };
        buttons[6]["Enemy4"] = new List<int>() { 43, 49 };
    }
    public static bool CheckWhetherButtonShouldBeSwaped(int currentLevel, string enemyTag, int techniqueId)
    {
        if (buttons[currentLevel][enemyTag].Count > 1)
        {
            foreach (int effectiveTechniqueId in buttons[currentLevel][enemyTag])
            {
                if (effectiveTechniqueId == techniqueId) return true;
            }
        }
        return false;

    }
    public static int SwapButton(int currentLevel, string enemyTag, int techniqueId)
    {
        while (true)
        {
            int randomButton = Random.Range(0, buttons[currentLevel][enemyTag].Count);
            if (buttons[currentLevel][enemyTag][randomButton] != techniqueId)
                return buttons[currentLevel][enemyTag][randomButton];
        }
    }
    static ButtonChanger()
    {
        FillDictionary();
    }
}
