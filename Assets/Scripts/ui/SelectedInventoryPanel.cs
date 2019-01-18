using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedInventoryPanel : MonoBehaviour
{
    [SerializeField] GameObject itemDescriptionPanel;

    // Use this for initialization
    void Start()
    {
        updateinventory();
    }

    void activateAllSlot()
    {

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void updateinventory()
    {
        //activateAllSlot();
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("invSlot") && gameGlobal.GLOBAL_selectedObject != null)
                if ((child.gameObject.GetComponent<SelectedObjInvSlot>().slotIndex + 1) > gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().invSize)
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
        }
    }

    public void itemDescription(int itemIndex)
    {
        if (gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemIndex] != null)
        {
            itemDescriptionPanel.SetActive(true);
            itemDescriptionPanel.GetComponent<ItemDescriptionPanel>().isPlayerInv = false;
        }
        else
            itemDescriptionPanel.SetActive(false);
        itemDescriptionPanel.GetComponent<ItemDescriptionPanel>().itemIndex = itemIndex;
    }

}
