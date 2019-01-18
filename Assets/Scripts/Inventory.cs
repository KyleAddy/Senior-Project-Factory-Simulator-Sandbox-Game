using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public ItemSO[] inventory = new ItemSO[25];
    public int invSize = 25;


    // Use this for initialization
    void Start()
    {
      //  for (int i = 0; i < inventory.Length; i++)
        //    inventory[i] = null;
    }
}
