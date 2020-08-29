using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class SwipeSystem : MonoBehaviour
{
    public Scrollbar scrollBar;
    float scrollPosition = 0;
    float distance = 0;
    float[] currentPositionsOfScrollItems;
    public HorizontalLayoutGroup horizontalLayoutGroup;
    public GameObject backButton;
    public GameObject techButton;
    public Sprite[] techSprites;
    public Animator playerAnimator;
    public string techName;
    private bool IsCenterPosition(int i)
    {
        return scrollPosition < currentPositionsOfScrollItems[i] + (distance / 2) && scrollPosition > currentPositionsOfScrollItems[i] - (distance / 2);
    }
    void Start()
    {
        SetProperPaddingDependingOnResolution();
        if (backButton != null && techButton != null)
            SetPositionOfButtons();
        currentPositionsOfScrollItems = new float[transform.childCount];
        distance = 1f / (currentPositionsOfScrollItems.Length - 1f);
    }
    void Update()
    {
        ResetCurrentPositionsOfScrollItems();
        SwipeItems();
        ChangeButtonsSizeDuringSwiping();
    }
    public void PlayAnimOfTechOnClick()
    {
        switch (techName)
        {
            case "ageuke_stamp":
                playerAnimator.SetInteger("idTechnique", 37);
                break;
            case "gedanbarai_stamp":
                playerAnimator.SetInteger("idTechnique", 38);
                break;
            case "shutouke_stamp":
                playerAnimator.SetInteger("idTechnique", 41);
                break;
            case "soto_udeuke_stamp":
                playerAnimator.SetInteger("idTechnique", 42);
                break;
            case "uchi_udeuke_stamp":
                playerAnimator.SetInteger("idTechnique", 46);
                break;
            case "oizuki_stamp":
                playerAnimator.SetInteger("idTechnique", 36);
                break;
            case "nukite_stamp":
                playerAnimator.SetInteger("idTechnique", 39);
                break;
            case "yoko_enpiuchi_stamp":
                playerAnimator.SetInteger("idTechnique", 44);
                break;
            case "gyakuzuki_stamp":
                playerAnimator.SetInteger("idTechnique", 47);
                break;
            case "kizamizuki_stamp":
                playerAnimator.SetInteger("idTechnique", 48);
                break;
            case "tate_urakenuchi_stamp":
                playerAnimator.SetInteger("idTechnique", 49);
                break;
            case "maegeri_stamp":
                playerAnimator.SetInteger("idTechnique", 35);
                break;
            case "yoko_geri_kekomi_stamp":
                playerAnimator.SetInteger("idTechnique", 40);
                break;
            case "mawashigeri_stamp":
                playerAnimator.SetInteger("idTechnique", 43);
                break;
            case "yoko_geri_keage_stamp":
                playerAnimator.SetInteger("idTechnique", 45);
                break;
            case "ushirogeri_stamp":
                playerAnimator.SetInteger("idTechnique", 50);
                break;
            default:
                break;
        }
        playerAnimator.SetTrigger("technique");
    }
    private void SetPositionOfButtons()
    {
        Vector3 v3back = backButton.transform.localPosition;
        Vector3 v3tech = techButton.transform.localPosition;
        if (Screen.width/Screen.height >= 2)
        {
            v3back.x = -950f;
            v3tech.x = 950f;
        }
        else
        {
            v3back.x = -825f;
            v3tech.x = 825f;
        }
        backButton.transform.localPosition = v3back;
        techButton.transform.localPosition = v3tech;
    }
    private void SetProperPaddingDependingOnResolution()
    {
        if (Screen.width / Screen.height >= 2)
        {
            if (Screen.width != 2960)
            {
                horizontalLayoutGroup.padding.left = (Screen.currentResolution.width - 160) / 2;
                horizontalLayoutGroup.padding.right = (Screen.currentResolution.width - 160) / 2;
                horizontalLayoutGroup.spacing = 320;
            }
            else
            {
                horizontalLayoutGroup.padding.left = (Screen.currentResolution.width - 100) / 2;
                horizontalLayoutGroup.padding.right = (Screen.currentResolution.width - 100) / 2;
                horizontalLayoutGroup.spacing = 340;
            }
        }
        else
        {
            horizontalLayoutGroup.padding.left = (Screen.currentResolution.width - 400) / 2;
            horizontalLayoutGroup.padding.right = (Screen.currentResolution.width - 400) / 2;
            horizontalLayoutGroup.spacing = 340;
        }

    }
    private void ResetCurrentPositionsOfScrollItems()
    {
        for (int i = 0; i < currentPositionsOfScrollItems.Length; i++)
            currentPositionsOfScrollItems[i] = distance * i;
    }
    private void UpdateScrollBarValue()
    {
        for (int i = 0; i < currentPositionsOfScrollItems.Length; i++)
            if (IsCenterPosition(i))
                scrollBar.value = Mathf.Lerp(scrollBar.value, currentPositionsOfScrollItems[i], 0.1f);
    }
    private void SwipeItems()
    {
        if (Input.GetMouseButton(0))
            scrollPosition = scrollBar.value;
        else
            UpdateScrollBarValue();
    }
    private void ChangeButtonsSizeDuringSwiping()
    {
        for (int i = 0; i < currentPositionsOfScrollItems.Length; i++)
            if (IsCenterPosition(i))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);

                if (backButton != null && techButton != null)
                {
                    techButton.GetComponent<Image>().sprite = techSprites[i];
                    techName = techSprites[i].name;
                }
                ScaleNotActiveScrollItems(i);
            }
    }
    private void ScaleNotActiveScrollItems(int currentActiveScrollItem)
    {
        for (int j = 0; j < currentPositionsOfScrollItems.Length; j++)
        {
            if (j != currentActiveScrollItem)
            {
                transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.6f, 0.6f), 0.1f);
                //add switching buttons
            }
        }
    }
}
