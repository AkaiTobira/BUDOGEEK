using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YenSystem : MonoBehaviour
{
    public int yen = 0;
    public Text yenText;
    public Animator yenAnimator;
    void Start()
    {
        yen = PlayerPrefs.GetInt("Currency");
        yenText.text = "" + yen;

    }
    public void AddToWallet(int value)
    {
        yen += value;
        yenText.text = "" + yen;
    }
    public void DropYen(int value)
    {
        yenAnimator.SetTrigger("DropYen");
        StartCoroutine(WaitBeforeAddToWallet(value));
    }
    IEnumerator WaitBeforeAddToWallet(int value)
    {
        yield return new WaitForSeconds(1.5f);
        AddToWallet(value);
    }
    public void SaveYen()
    {
        PlayerPrefs.SetInt("Currency", yen);
    }
    public void DroppingYenSystem()
    {
        int tmp;
        switch (PlayerPrefs.GetInt("CurrentLevel"))
        {
            case 0:
                break;
            case 1:
                tmp = Random.Range(0, 10);
                if (tmp == 1)
                    DropYen(1);
                break;
            case 2:
                tmp = Random.Range(0, 9);
                if (tmp == 1)
                    DropYen(1);
                break;
            case 3:
                tmp = Random.Range(0, 8);
                if (tmp == 1)
                    DropYen(2);
                break;
            case 4:
                tmp = Random.Range(0, 7);
                if (tmp == 1)
                    DropYen(2);
                break;
            case 5:
                tmp = Random.Range(0, 6);
                if (tmp == 1)
                    DropYen(2);
                break;
            case 6:
                tmp = Random.Range(0, 5);
                if (tmp == 1)
                    DropYen(3);
                break;
            default:
                break;
        }
    }
}
