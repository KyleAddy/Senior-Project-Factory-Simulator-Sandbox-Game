using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvSlot : MonoBehaviour
{

    [SerializeField] Image slotimage;
    [SerializeField] GameObject globalGameObj;
    public int slotIndex;

    // Update is called once per frame
    void Update()
    {
       
            if (globalGameObj.GetComponent<Inventory>().inventory[slotIndex] != null)
            {
                slotimage.enabled = true;
                slotimage.GetComponent<Image>().sprite = globalGameObj.GetComponent<Inventory>().inventory[slotIndex].itemSprite;
            }
            else
                slotimage.enabled = false;
        }
    
}
