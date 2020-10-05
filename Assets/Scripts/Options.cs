using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider[] sliders;
    // Start is called before the first frame update
    void Start()
    {
        GetSlidersValue();
    }
    public void GetSlidersValue()
    {
        sliders[0].value = PlayerPrefs.GetFloat("Slider0");
        sliders[1].value = PlayerPrefs.GetFloat("Slider1");
        sliders[2].value = PlayerPrefs.GetFloat("Slider2");
        sliders[3].value = PlayerPrefs.GetFloat("Slider3");
    }
    public void SaveSlidersValue()
    {
        PlayerPrefs.SetFloat("Slider0", sliders[0].value);
        PlayerPrefs.SetFloat("Slider1", sliders[1].value);
        PlayerPrefs.SetFloat("Slider2", sliders[2].value);
        PlayerPrefs.SetFloat("Slider3", sliders[3].value);
    }
}
