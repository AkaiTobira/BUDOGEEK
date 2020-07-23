using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public Animation animation;
    public int[] tabOfNinjasId;
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        animation.Play();
        PlayPlateNinjaAnimation();
    }

    public void SpawnRandomNinja()
    {
        if (currentLevel == 0)
        {

        }
            int tmp = Random.Range(0, 3);
        switch(tmp)
        {
            case 1:
                animation.Play();
                break;
            case 2:
                animation.Play();
                break;
            case 3:
                animation.Play();
                break;
            case 4:
                animation.Play();
                break;
        }

    }
    public void PlayPillowNinjaAnimation()
    {
        if (animation.IsPlaying("pillow_ninja"))
            StartCoroutine(ThrowPillow());
    }
    IEnumerator ThrowPillow()
    {
        yield return new WaitForSeconds(0.25f);
        animation.Play("pillow");
    }
    public void PlayPlateNinjaAnimation()
    {
        if (animation.IsPlaying("plate_ninja"))
            StartCoroutine(ThrowPlate());
    }
    IEnumerator ThrowPlate()
    {
        yield return new WaitForSeconds(0.5f);
        animation.Play("plate");
    }
}
