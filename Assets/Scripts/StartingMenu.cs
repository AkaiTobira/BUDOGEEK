using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingMenu : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.SetTrigger("start");
    }
}
