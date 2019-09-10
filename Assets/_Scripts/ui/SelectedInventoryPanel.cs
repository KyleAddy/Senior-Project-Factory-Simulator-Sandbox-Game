using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedInventoryPanel : MonoBehaviour
{
    [SerializeField] GameObject itemDescriptionPanel;
    [SerializeField] GameObject globalGameObj;

    // Use this for initialization
    void Start()
    {
        globalGameObj = GlobalVariables.gameManager;
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
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("invSlot") && GlobalVariables.GLOBAL_selectedObject != null)
                if ((child.gameObject.GetComponent<SelectedObjInvSlot>().slotIndex + 1) > GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().invSize)
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
        }
    }

    public void itemDescription(int itemIndex)
    {
        if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemIndex] != null)
        {
            itemDescriptionPanel.SetActive(true);
            itemDescriptionPanel.GetComponent<ItemDescriptionPanel>().isPlayerInv = false;
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
        if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemSlot] != null)
        {
            int emptySlot = -1;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                ItemSO selectedItem = GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemSlot];
                //move all of that item to the other inventory
                for (int i = 0; i < GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().invSize; i++)//loop through the players inventory
                {
                    if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[i] == selectedItem)//if an item matches then transfer it
                    {
                        emptySlot = -1;
                        emptySlot = GlobalFunctions.findEmptArraySlot(globalGameObj.GetComponent<Inventory>().inventory, globalGameObj.GetComponent<Inventory>().invSize);
                        if (emptySlot == -1)//if there is no space in other inventory then return
                        {
                            return;
                        }
                        globalGameObj.GetComponent<Inventory>().inventory[emptySlot] = selectedItem;
                        GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[i] = null;
                    }
                }
            }
            else
            {
                //tranfer just that item
                emptySlot = -1;
                emptySlot = GlobalFunctions.findEmptArraySlot(globalGameObj.GetComponent<Inventory>().inventory, globalGameObj.GetComponent<Inventory>().invSize);
                if (emptySlot != -1)
                {
                    globalGameObj.GetComponent<Inventory>().inventory[emptySlot] = GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemSlot];
                    GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemSlot] = null;
                }
            }            
        }
    }

}
