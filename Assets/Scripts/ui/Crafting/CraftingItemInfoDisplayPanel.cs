using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingItemInfoDisplayPanel : MonoBehaviour
{
    [SerializeField] Image progBar;
    [SerializeField] GameObject itemName;
    [SerializeField] Image itemImage;
    [SerializeField] Sprite none;

    // Start is called before the first frame update
    void Start()
    {
        progBar.GetComponent<Image>().fillAmount = 0;
        itemName.GetComponent<TextMeshProUGUI>().text = "";
        itemImage.GetComponent<Image>().sprite = none;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgBar();
        UpdateItemInfo();
    }

    void UpdateProgBar()
    {
        if (gameGlobal.GLOBAL_selectedObject != null)
        {
            if (gameGlobal.GLOBAL_selectedObject.GetComponent<Crafting>().isCrafting)
            {
                progBar.GetComponent<Image>().fillAmount = gameGlobal.GLOBAL_selectedObject.GetComponent<Crafting>().progNumber;
            }
            else
            {
                progBar.GetComponent<Image>().fillAmount = 0;
            }
        }
    }

    void UpdateItemInfo()
    {
        if (gameGlobal.GLOBAL_selectedObject != null)
        {
            if (gameGlobal.GLOBAL_selectedObject.GetComponent<Crafting>().isCrafting)
            {
                itemName.GetComponent<TextMeshProUGUI>().text = gameGlobal.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.itemName;
                itemImage.GetComponent<Image>().sprite = gameGlobal.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.itemSprite;
            }
            else
            {
                itemName.GetComponent<TextMeshProUGUI>().text = "";
                itemImage.GetComponent<Image>().sprite = none;
            }
        }
    }
}
