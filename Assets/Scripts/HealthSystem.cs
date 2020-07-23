using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public PlayerController player;
    public Image[] heartImages;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void ChangeTransparencyOfHeartImage(Image heartImage)
    {
        Animator heartAnimator = heartImage.GetComponent<Animator>();
        heartAnimator.SetBool("lose_hp", true);
        heartAnimator.SetBool("gain_hp", false);
        /*
        Color tmpColor = heartImage.color;
        tmpColor.a = 0.2F;
        heartImage.color = tmpColor;
        */
    }
    private void RestoreTransparencyOfHeartImage(Image heartImage)
    {
        Animator heartAnimator = heartImage.GetComponent<Animator>();
        heartAnimator.SetBool("lose_hp", false);
        heartAnimator.SetBool("gain_hp", true);
        /*
        Color tmpColor = heartImage.color;
        tmpColor.a = 1F;
        heartImage.color = tmpColor;
        */
    }
    public void ChangeHealthStatus(int hp)
    {
        Debug.Log(hp);
        ChangeTransparencyOfHeartImage(heartImages[hp]);
        /*
        if (hp == 2)
            ChangeTransparencyOfHeartImage(heartImage3.heartImage);
        if (hp == 1)
            ChangeTransparencyOfHeartImage(heartImage2);
        if (hp == 0)
            ChangeTransparencyOfHeartImage(heartImage1);
        */
    }
}
