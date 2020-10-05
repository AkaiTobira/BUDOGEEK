using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public float maxVolumeOfBgMusic;
    public AudioSource backgroundMusic;
    public Button[] tabOfButtons;
    public AudioSource[] blocks;
    public AudioSource[] punches;
    public AudioSource[] kicks;
    // Start is called before the first frame update
    void Start()
    {
        FluentVolumeChange();
    }
    private void FluentVolumeChange()
    {
        StartCoroutine(TurningUpVolume());
    }
    IEnumerator TurningUpVolume()
    {
        for (int i = 0; i < 100; i++)
        {
            backgroundMusic.volume += 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void SetMaxVolumeOfBgMusic(float value)
    {
        maxVolumeOfBgMusic = value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySoundOnButtonClick(AudioSource sound)
    {
        sound.Play();
    }
    public void PlayRandomSoundOnButtonClick(string letter)
    {
        int rndId;
        rndId = Random.Range(0, 4);
        switch (letter)
        {
            case "b":
                ChooseTypeOfTechniques(blocks, rndId);
                break;
            case "p":
                ChooseTypeOfTechniques(punches, rndId);
                break;
            case "k":
                rndId = Random.Range(0, 5);
                ChooseTypeOfTechniques(kicks, rndId);
                break;
            default:
                break;
        }

    }
    public void ChooseTypeOfTechniques(AudioSource[] sounds, int rndId)
    {
        sounds[rndId].Play();
    }
}
