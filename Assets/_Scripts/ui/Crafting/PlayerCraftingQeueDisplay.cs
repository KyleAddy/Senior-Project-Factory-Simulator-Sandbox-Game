using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCraftingQeueDisplay : MonoBehaviour
{
    [SerializeField] GameObject globalGameObj;

    [SerializeField] Image progBar;
    [SerializeField] Sprite none;

    [SerializeField] GameObject[] qeueDisplay;

    // Start is called before the first frame update
    void Start()
    {
        globalGameObj = GlobalVariables.gameManager;
        progBar.GetComponent<Image>().fillAmount = 0;
        for (int i = 0; i < qeueDisplay.Length; i++)
            qeueDisplay[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgBar();
        UpdateCraftingQeueDisplay();
    }

    void UpdateProgBar()
    {
            if  (globalGameObj.GetComponent<playerCrafting>().isCrafting)
            {
                progBar.GetComponent<Image>().fillAmount = globalGameObj.GetComponent<playerCrafting>().progNumber;
            }
            else
            {
                progBar.GetComponent<Image>().fillAmount = 0;
            }
    }

    void UpdateCraftingQeueDisplay()
    {
        for(int i = 0; i < qeueDisplay.Length; i++ )
            if (globalGameObj.GetComponent<playerCrafting>().craftingQueue.Count > i)
            {
                qeueDisplay[i].SetActive(true);
                qeueDisplay[i].transform.GetChild(0).GetComponent<Image>().sprite = globalGameObj.GetComponent<playerCrafting>().craftingQueue[i].itemSprite;
            }
            else
            {
                qeueDisplay[i].SetActive(false);
            }
     }
}

