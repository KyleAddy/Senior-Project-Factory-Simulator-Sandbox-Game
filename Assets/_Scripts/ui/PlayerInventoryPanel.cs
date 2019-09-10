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
        globalGameObj = GlobalVariables.gameManager;
        updateinventory();        
    }

    public void PlacingItemInWorld(int index)
    {
        globalGameObj.GetComponent<PlacingItemInWorld>().createBluePrint(index);
    }


    public void updateinventory()
    {
        foreach (Transform child in transform)
        {
            if (globalGameObj == null)
            {
                globalGameObj = GlobalVariables.gameManager;
            }

            if (child.gameObject.CompareTag("invSlot"))
                if ((child.gameObject.GetComponent<PlayerInvSlot>().slotIndex + 1) > globalGameObj.GetComponent<Inventory>().invSize)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
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

    public void DisableItemDescription()
    {
        itemDescriptionPanel.SetActive(false);
    }

    public void transferItem(int itemSlot)
    {
        if (globalGameObj == null)
        {
            globalGameObj = GlobalVariables.gameManager;
        }

        if (globalGameObj.GetComponent<Inventory>().inventory[itemSlot] != null && GlobalVariables.GLOBAL_selectedObject != null)
        {
            int emptySlot = -1;
             
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ItemSO selectedItem = globalGameObj.GetComponent<Inventory>().inventory[itemSlot];
                //move all of that item to the other inventory
                for (int i = 0; i < globalGameObj.GetComponent<Inventory>().invSize; i++)//loop through the players inventory
                {
                    if (globalGameObj.GetComponent<Inventory>().inventory[i] == selectedItem)//if an item matches then transfer it
                    {
                        emptySlot = -1;
                        emptySlot = GlobalFunctions.findEmptArraySlot(GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory, GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().invSize);
                        if (emptySlot == -1)//if there is no space in other inventory then return
                        {
                            return;
                        }                        
                        GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[emptySlot] = selectedItem;
                        globalGameObj.GetComponent<Inventory>().inventory[i] = null;                        
                    }
                }
            }
            else
            {
                //move that item tot he other inventory
                emptySlot = -1;
                emptySlot = GlobalFunctions.findEmptArraySlot(GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory, GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().invSize);
                if (emptySlot != -1)
                {
                    GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[emptySlot] = globalGameObj.GetComponent<Inventory>().inventory[itemSlot];
                    globalGameObj.GetComponent<Inventory>().inventory[itemSlot] = null;
                }
            }                                     
        }
    }
}
