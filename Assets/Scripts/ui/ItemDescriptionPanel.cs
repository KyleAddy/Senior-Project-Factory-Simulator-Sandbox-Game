using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemDescriptionPanel : MonoBehaviour
{
    public int itemIndex;
    [SerializeField] GameObject textField;
    [SerializeField] GameObject image;
    [SerializeField] GameObject globalGameObj;
    
    public bool isPlayerInv;

    // Use this for initialization
    private void Start()
    {
        isPlayerInv = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        updateinfo();
    }
    void updateinfo()
    {
        if (isPlayerInv)
        {
            if (globalGameObj.GetComponent<Inventory>().inventory[itemIndex] != null)
            {
                textField.GetComponent<Text>().text = globalGameObj.GetComponent<Inventory>().inventory[itemIndex].itemDescription;
                image.GetComponent<Image>().sprite = globalGameObj.GetComponent<Inventory>().inventory[itemIndex].itemSprite;
            }
            else
                gameObject.SetActive(false);
        }
        else
            if (gameGlobal.GLOBAL_selectedObject != null)
            {
                if (gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemIndex] != null)
                {
                    textField.GetComponent<Text>().text = gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemIndex].itemDescription;
                    image.GetComponent<Image>().sprite = gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().inventory[itemIndex].itemSprite;
                }
                else
                    gameObject.SetActive(false);
            }
    }

    void diableItemDescription()
    {
        gameObject.SetActive(false);
    }
}
