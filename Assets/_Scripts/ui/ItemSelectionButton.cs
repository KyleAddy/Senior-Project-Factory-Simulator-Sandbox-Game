using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionButton : MonoBehaviour
{
    public ItemSO buttonItem;
    public Button button;
    void start()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = buttonItem.itemSprite;
    }

    // Update is called once per frame
    void Update()
    {
        selectButton();
    }

    public void SetSelectedItem(){
        if(GlobalVariables.GLOBAL_selectedObject != null){
            if(GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] == "withdraw" || GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] == "deposit"){
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().itemSelectionArray[GlobalVariables.GLOBAL_selectedIndex] = buttonItem;
                GlobalVariables.GLOBAL_selectedIndex++;
            }
        }
    }

    void selectButton(){
        if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().itemSelectionArray[GlobalVariables.GLOBAL_selectedIndex] == buttonItem)
            button.Select(); 
    }
}
