using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TechniqueMatcher
{
    private static Dictionary<string, List<int>> enemyToTechniqueIndex = new Dictionary<string, List<int>>();
    private static void FillDictionary()
    {
        enemyToTechniqueIndex["Enemy1"] = new List<int>() { 1, 3, 4, 7, 8, 12, 15, 16, 18, 19, 20, 23, 24, 28, 31, 32, 34, 35, 36, 39, 40, 44, 47, 48, 50 };
        enemyToTechniqueIndex["Enemy2"] = new List<int>() { 2, 5, 13, 21, 29, 37, 45 };
        enemyToTechniqueIndex["Enemy3"] = new List<int>() { 6, 9, 10, 14, 22, 25, 26, 30, 38, 41, 42, 46 };
        enemyToTechniqueIndex["Enemy4"] = new List<int>() { 11, 17, 27, 33, 43, 49 };
    }
    public static bool CheckIfTechniqueIsEffective(string enemyTag, int techniqueId)
    {
        foreach (int effectiveTechniqueId in enemyToTechniqueIndex[enemyTag])
        {
            if (effectiveTechniqueId == techniqueId) return true;
        }
        return false;
    }
    static TechniqueMatcher()
    {
        FillDictionary();
    }
}
