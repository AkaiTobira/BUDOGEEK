using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(FindObjectOfType<PlayerController>());
        DontDestroyOnLoad(FindObjectOfType<LevelManager>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
