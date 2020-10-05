using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YenSystem : MonoBehaviour
{
    public int yen = 0;
    public Text yenText;
    public Animator yenAnimator;
    public PlayerController player;
    public Animator leftKiay;
    public Animator rightKiay;
    private int numerOfNotDropYen = 0;
    public AudioSource yenSound;
    public AudioSource[] kiaySounds;
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
        yenSound.Play();
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
        int probability = Random.Range(0, 100);
        if (probability < GetUpperBoundProbabilityPerLevel())
        {
            DropYen(GetAmountOfYenPerLevel());
            ShowKiay();
            numerOfNotDropYen = 0;
        }
        else
            numerOfNotDropYen++;
    }
    private int GetUpperBoundProbabilityPerLevel()
    {
        switch (PlayerPrefs.GetInt("CurrentLevel"))
        {
            case 0:
                return 0;
            case 1:
                return 5 + 5 * numerOfNotDropYen;
            case 2:
                return 6 + 6 * numerOfNotDropYen;
            case 3:
                return 7 + 7 * numerOfNotDropYen;
            case 4:
                return 8 + 8 * numerOfNotDropYen;
            case 5:
                return 9 + 9 * numerOfNotDropYen;
            case 6:
                return 10 + 10 * numerOfNotDropYen;
            default:
                return -1;
        }
    }
    private int GetAmountOfYenPerLevel()
    {
        switch (PlayerPrefs.GetInt("CurrentLevel"))
        {
            case 0:
                return 0;
            case 1:
            case 2:
                return 1;
            case 3:
            case 4:
            case 5:
                return 2;
            case 6:
                return 3;
            default:
                return -1;
        }
    }

    public void ShowKiay()
    {
        if (player.facingRight)
        {
            rightKiay.SetTrigger("RightKiay");
        }
        else if (!player.facingRight)
        {
            leftKiay.SetTrigger("LeftKiay");
        }
        //int rndId = Random.Range(0, 2);
        kiaySounds[0].Play();
    }
}
