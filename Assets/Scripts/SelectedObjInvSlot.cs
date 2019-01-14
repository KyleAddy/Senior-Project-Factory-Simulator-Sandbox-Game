﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedObjInvSlot : MonoBehaviour
{

    [SerializeField] Image slotimage;
    public int slotIndex;

    // Update is called once per frame
    void Update()
    {
        if (gameGlobal.GLOBAL_selectedObject != null)
        {
            if (gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[slotIndex] != null)
            {
                slotimage.enabled = true;
                slotimage.GetComponent<Image>().sprite = gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[slotIndex].itemSprite;
            }
            else
                slotimage.enabled = false;
        }
    }
}
