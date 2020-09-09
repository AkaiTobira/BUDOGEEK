using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingGame : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        StartCoroutine(ChangeSceneWhenAnimFinished());
    }
    IEnumerator ChangeSceneWhenAnimFinished()
    {
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("start");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
