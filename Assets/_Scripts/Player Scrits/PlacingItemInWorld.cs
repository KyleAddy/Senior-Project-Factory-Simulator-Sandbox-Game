using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingItemInWorld : MonoBehaviour
{
    public GameObject blueprint;
    public GameObject createdObject;
    public bool isCreated = false;



    public void createBluePrint(int invIndex)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (GetComponent<Inventory>().inventory[invIndex] != null)
            {
                if (GetComponent<Inventory>().inventory[invIndex].itemPrefab != null)
                {
                    
                    if (GlobalVariables.GLOBAL_selectedObject == null)
                    {
                        GetComponent<ui>().CloseGUI();
                        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        mousePos.y = .5f;
                        var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                        if (GetComponent<Inventory>().inventory[invIndex].itemBlueprint != null)
                        {
                            createdObject = Instantiate(GetComponent<Inventory>().inventory[invIndex].itemBlueprint, objectPos, Quaternion.identity);
                        }
                        else
                        {
                            createdObject = Instantiate(blueprint, objectPos, Quaternion.identity);
                        }
                        createdObject.GetComponent<blueprint>().prefabToPlace = GetComponent<Inventory>().inventory[invIndex].itemPrefab;
                        createdObject.GetComponent<blueprint>().invIndex = invIndex;
                        isCreated = true;
                    }                                       
                }
            }
        }
                
    }
}
