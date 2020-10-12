using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySettings : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] backgrounds;
    void Start()
    {
        SetBackground();
        SetItems(PlayerPrefs.GetInt("CurrentLevel"));
    }
    public void SetItems(int currentLevel)
    {
        if (PlayerPrefs.GetString("kimono") == "BasicKimono")
        {
            if (PlayerPrefs.GetInt($"belt{currentLevel}") == 0)
                players[0].SetActive(true);
            else if (PlayerPrefs.GetInt($"belt{currentLevel}") == 1)
                players[1].SetActive(true);
        }
        else if (PlayerPrefs.GetString("kimono") == "BlackKimono")
        {
            if (PlayerPrefs.GetInt($"belt{currentLevel}") == 0)
                players[2].SetActive(true);
            else if (PlayerPrefs.GetInt($"belt{currentLevel}") == 1)
                players[3].SetActive(true);
        }
    }
    public void SetBackground()
    {
        switch (PlayerPrefs.GetString("background"))
        {
            case "BasicBackground":
                backgrounds[0].SetActive(true);
                break;
            case "DojoBackground":
                backgrounds[1].SetActive(true);
                break;
                /*
            case "GroveBackground":
                backgrounds[1].SetActive(true);
                break;
            case "MountainBackground":
                backgrounds[1].SetActive(true);
                break;
                */
            default:
                break;
        }
    }

    public void SetKimono()
    {
        switch (PlayerPrefs.GetString("kimono"))
        {
            case "BasicKimono":
                switch (PlayerPrefs.GetString("belt"))
                {
                    case "BasicBelt":
                        players[0].SetActive(true);
                        break;
                    case "PinkBelt":
                        players[1].SetActive(true);
                        break;
                    case "MasterBelt":
                        players[2].SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case "BlackKimono":
                switch (PlayerPrefs.GetString("belt"))
                {
                    case "BasicBelt":
                        players[3].SetActive(true);
                        break;
                    case "PinkBelt":
                        players[4].SetActive(true);
                        break;
                    case "MasterBelt":
                        players[5].SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case "GoldenKimono":
                switch (PlayerPrefs.GetString("belt"))
                {
                    case "BasicBelt":
                        players[6].SetActive(true);
                        break;
                    case "PinkBelt":
                        players[7].SetActive(true);
                        break;
                    case "MasterBelt":
                        players[8].SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
    public void SetItem()
    {
        switch (PlayerPrefs.GetString("kimono"))
        {
            case "BasicKimono":
                switch (PlayerPrefs.GetString("belt"))
                {
                    case "BasicBelt":
                        players[0].SetActive(true);
                        break;
                    case "PinkBelt":
                        players[1].SetActive(true);
                        break;
                    case "MasterBelt":
                        players[2].SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case "BlackKimono":
                switch (PlayerPrefs.GetString("belt"))
                {
                    case "BasicBelt":
                        players[3].SetActive(true);
                        break;
                    case "PinkBelt":
                        players[4].SetActive(true);
                        break;
                    case "MasterBelt":
                        players[5].SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case "GoldenKimono":
                switch (PlayerPrefs.GetString("belt"))
                {
                    case "BasicBelt":
                        players[6].SetActive(true);
                        break;
                    case "PinkBelt":
                        players[7].SetActive(true);
                        break;
                    case "MasterBelt":
                        players[8].SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        switch (PlayerPrefs.GetString("background"))
        {
            case "BasicBackground":
                backgrounds[0].SetActive(true);
                break;
            case "SpringBackground":
                backgrounds[1].SetActive(true);
                break;
            case "SummerBackground":
                backgrounds[2].SetActive(true);
                break;
            case "AutumnBackground":
                backgrounds[3].SetActive(true);
                break;
            case "WinterBackground":
                backgrounds[4].SetActive(true);
                break;
            default:
                break;
        }
    }
}
