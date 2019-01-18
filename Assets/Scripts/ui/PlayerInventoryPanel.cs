using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryPanel : MonoBehaviour
{
    [SerializeField] GameObject itemDescriptionPanel;
    [SerializeField] GameObject globalGameObj;

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
            if (child.gameObject.CompareTag("invSlot"))
                if ((child.gameObject.GetComponent<PlayerInvSlot>().slotIndex + 1) > globalGameObj.GetComponent<Inventory>().invSize)
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
        }
    }

    public void itemDescription(int itemIndex)
    {
        if (globalGameObj.GetComponent<Inventory>().inventory[itemIndex] != null)
        {
            itemDescriptionPanel.SetActive(true);
            itemDescriptionPanel.GetComponent<ItemDescriptionPanel>().isPlayerInv = true;
        }
        else
            itemDescriptionPanel.SetActive(false);
        itemDescriptionPanel.GetComponent<ItemDescriptionPanel>().itemIndex = itemIndex;
    }
}
