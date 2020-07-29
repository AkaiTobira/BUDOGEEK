using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;
    public Animator countdownAnimator;
    // Start is called before the first frame update
    void Start()
    {
        countdownText = GetComponent<Text>();
        countdownAnimator = GetComponent<Animator>();
        countdownText.text = "3";
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void CountingDown()
    {
        if (countdownText.text == "3")
        {
            StartCoroutine(WaitOneSecond());
            countdownText.text = "2";
        }
        else if (countdownText.text == "2")
        {
            StartCoroutine(WaitOneSecond());
            countdownText.text = "1";
        }
        else if (countdownText.text == "1")
        {
            StartCoroutine(WaitOneSecond());
            countdownText.text = "0";
        }

    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1f);
    }
}
