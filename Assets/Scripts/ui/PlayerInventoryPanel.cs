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

    public void updateinventory()
    {
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
        if (globalGameObj.GetComponent<Inventory>().inventory[itemIndex] != null && !Input.GetKey(KeyCode.LeftShift))
        {
            itemDescriptionPanel.SetActive(true);
            itemDescriptionPanel.GetComponent<ItemDescriptionPanel>().isPlayerInv = true;
        }
        else
            itemDescriptionPanel.SetActive(false);
        itemDescriptionPanel.GetComponent<ItemDescriptionPanel>().itemIndex = itemIndex;
    }

    public void transferItem(int itemSlot)
    {
        if (globalGameObj.GetComponent<Inventory>().inventory[itemSlot] != null)
        {
            int emptySlot = -1;
            if (gameGlobal.GLOBAL_selectedObject != null)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    emptySlot = globalGameObj.GetComponent<gameGlobal>().findEmptArraySlot(gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().inventory, gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().invSize);
                    if (emptySlot != -1)
                    {
                        gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[emptySlot] = globalGameObj.GetComponent<Inventory>().inventory[itemSlot];
                        globalGameObj.GetComponent<Inventory>().inventory[itemSlot] = null;
                    }
                        
                }
            }
        }
    }
}
