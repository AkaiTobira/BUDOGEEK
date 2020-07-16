using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechniqueButton : MonoBehaviour
{
    public void ChangeTechniqueOnClick(int idTechnique)
    {
        GetComponent<Animator>().SetInteger("IdAttack", idTechnique);
    }
}
