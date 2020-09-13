using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTutorial : MonoBehaviour
{
    public GameObject tutorial;
    public string nameOfTutorial;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(nameOfTutorial) == 0)
        {
            ShowInstruction();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowInstruction()
    {
        StartCoroutine(WaitUnlessBeingReadyToSkipTutorial());
    }
    IEnumerator WaitUnlessBeingReadyToSkipTutorial()
    {
        tutorial.SetActive(true);
        yield return new WaitForSeconds(3f);
        while (true)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase.Equals(TouchPhase.Ended))
                {
                    PlayerPrefs.SetInt(nameOfTutorial, 1);
                    tutorial.SetActive(false);
                    yield break;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
