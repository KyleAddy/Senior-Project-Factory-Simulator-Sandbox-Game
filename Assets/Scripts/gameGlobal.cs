using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameGlobal : MonoBehaviour {

	public static float GLOBAL_gridCellSize;
	public static int GLOBAL_worldX;
	public static int GLOBAL_worldZ;
	public static GameObject[,] GLOBAL_grid = new GameObject[10, 10];

	public static GameObject GLOBAL_selectedObject = null;
	public static int GLOBAL_selectedIndex = 0;

	// Use this for initialization
	void Start () {

		GLOBAL_gridCellSize = 1f;
		GLOBAL_worldX = 10;
		GLOBAL_worldZ = 10;
	}

    public int findEmptArraySlot(ItemSO[] array, int arraySize)
    {
        for (int i = 0; i < arraySize; i++)
        {
            if (array[i] == null)
            {
                return (i);
            }
        }
        return (-1);
    }

    public void PickUpItem()
    {
        //check to see if a object is selected
        if (GLOBAL_selectedObject == null)
        {
            return;
        }

        //check to see if the selected object has an inventory
        if (GLOBAL_selectedObject.GetComponent<Inventory>())
        {
            //try to move all items in the selected objects inventory to the players inventory
            //if you cant then return false and dont pick up the item
            int playerInv = 0;
            for (int itemInv = 0; itemInv < GLOBAL_selectedObject.GetComponent<Inventory>().invSize; itemInv++)
            {
                //check to see if there is a item in the selected objects inv at itemInv index
                if (GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemInv] != null)
                {
                    //go through the players inventory
                    for (/*playerInv initalized already*/; playerInv < GetComponent<Inventory>().invSize; playerInv++)
                    {
                        if(GetComponent<Inventory>().inventory[playerInv] == null)
                        {
                            GetComponent<Inventory>().inventory[playerInv] = GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemInv];
                            GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemInv] = null;                          
                            break;
                        }
                    }
                }
            }
        }

        int tempIndex = findEmptArraySlot(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
        if (tempIndex != -1)
        {
            //set empty slot in players inventory to the item that is being picked up
            GetComponent<Inventory>().inventory[tempIndex] = GLOBAL_selectedObject.GetComponent<ObjectItemSO>().itemSO;
            //destory the item that is being picked up
            Destroy(GLOBAL_selectedObject);

            GLOBAL_selectedObject = null;
            GetComponent<ui>().CloseGUI();
            //return because the item was picked up
            return;
        }
        //return because there is no selected object
        return;
    }
}
