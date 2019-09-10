using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameGlobal : MonoBehaviour {

    [SerializeField] ItemSO empty;

    void Awake()
    {
        GlobalVariables.gameManager = gameObject;
    }

        public void PickUpItem()
    {
        //check to see if a object is selected
        if (GlobalVariables.GLOBAL_selectedObject == null)
        {
            return;
        }

        //check to see if the selected object has an inventory
        if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>())
        {
            //try to move all items in the selected objects inventory to the players inventory
            //if you cant then return false and dont pick up the item
            int playerInv = 0;
            for (int itemInv = 0; itemInv < GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().invSize; itemInv++)
            {
                //check to see if there is a item in the selected objects inv at itemInv index
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemInv] != null)
                {
                    //go through the players inventory
                    for (/*playerInv initalized already*/; playerInv < GetComponent<Inventory>().invSize; playerInv++)
                    {
                        if(GetComponent<Inventory>().inventory[playerInv] == null || GetComponent<Inventory>().inventory[playerInv] == empty)
                        {
                            GetComponent<Inventory>().inventory[playerInv] = GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemInv];
                            GlobalVariables.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemInv] = null;                          
                            break;
                        }
                    }
                }
            }
        }

        int tempIndex = GlobalFunctions.findEmptArraySlot(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
        if (tempIndex != -1)
        {
            //set empty slot in players inventory to the item that is being picked up
            GetComponent<Inventory>().inventory[tempIndex] = GlobalVariables.GLOBAL_selectedObject.GetComponent<ObjectItemSO>().itemSO;
            //destory the item that is being picked up
            Destroy(GlobalVariables.GLOBAL_selectedObject);

            GlobalVariables.GLOBAL_selectedObject = null;
            GetComponent<ui>().CloseGUI();
            //return because the item was picked up
            return;
        }
        //return because there is no selected object
        return;
    }

    public void ClearInventory()
    {
        GetComponent<Inventory>().ClearInventory();
    }

    public void GivePlayerItem(ItemSO item, int quantity)
    {
        for(int i = 0; i < quantity; i++)
        {
            int slot = GlobalFunctions.findEmptArraySlot(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
            if (slot == -1)
            {
                return;
            }
            GetComponent<Inventory>().inventory[slot] = item;
        }        
    }
}
