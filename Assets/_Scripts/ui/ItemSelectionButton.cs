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

            if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
            {
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action == "withdraw" || GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action == "deposit")
                {
                    GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].itemSelected = buttonItem;
                    GlobalVariables.GLOBAL_selectedIndex++;
                }
            }     
            else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
            {
                if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action == "withdraw" || RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action == "deposit")
                {
                    RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].itemSelected = buttonItem;
                    GlobalVariables.GLOBAL_selectedIndex++;
                }
            }
        }
    }

    void selectButton(){
        if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
        {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].itemSelected == buttonItem)
            {
                button.Select();
            }
        }
        else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
        {
            if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].itemSelected == buttonItem)
            {
                button.Select();
            }
        }
    }
}
