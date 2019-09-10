using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField] ItemSO empty;
    public ItemSO[] inventory = new ItemSO[25];
    public int invSize = 25;

    public void ClearInventory()
    {
        for (int i = 0; i < invSize-1; i++)
        {
            inventory[i] = empty;
        }
    }
}
