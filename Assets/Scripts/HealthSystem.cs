using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public PlayerController player;
    public Image[] heartImages;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void ChangeTransparencyOfHeartImage(Image heartImage)
    {
        Animator heartAnimator = heartImage.GetComponent<Animator>();
        heartAnimator.SetBool("lose_hp", true);
        heartAnimator.SetBool("gain_hp", false);
    }
    private void RestoreTransparencyOfHeartImage(Image heartImage)
    {
        Animator heartAnimator = heartImage.GetComponent<Animator>();
        heartAnimator.SetBool("lose_hp", false);
        heartAnimator.SetBool("gain_hp", true);
    }
    public void ChangeHealthStatus(int hp)
    {
        ChangeTransparencyOfHeartImage(heartImages[hp]);
    }
}
