using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;
    public Animator countdownAnimator;
    void Start()
    {
        countdownAnimator = GetComponent<Animator>();
    }
    public IEnumerator CountingDown(int value)
    {
        while (value > 0)
        {
            countdownText.text = "" + value;
            countdownAnimator.SetTrigger("startCountingDown");
            yield return new WaitForSeconds(1f);
            value--;
            if (value == 0)
            {
                countdownText.text = "Start";
                countdownAnimator.SetTrigger("startCountingDown");
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
