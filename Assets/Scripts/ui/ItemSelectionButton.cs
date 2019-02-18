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
        if(gameGlobal.GLOBAL_selectedObject != null){
            if(gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] == "withdraw" || gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] == "deposit"){
                gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().itemSelectionArray[gameGlobal.GLOBAL_selectedIndex] = buttonItem;
                gameGlobal.GLOBAL_selectedIndex++;
            }
        }
    }

    void selectButton(){
        if (gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().itemSelectionArray[gameGlobal.GLOBAL_selectedIndex] == buttonItem)
            button.Select(); 
    }
}
