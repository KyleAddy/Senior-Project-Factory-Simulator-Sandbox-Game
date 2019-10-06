using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectionPanelController : MonoBehaviour
{
    public GameObject ItemSelectionPanel;

    // Start is called before the first frame update
    void Start()
    {
        ItemSelectionPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ItemSelectionPanelCheck();
        SetItemSelectedToNull();
    }

    void ItemSelectionPanelCheck(){
        if(GlobalVariables.GLOBAL_selectedObject != null){
            if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
            {
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action == "withdraw"
                || GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action == "deposit")
                {
                    ItemSelectionPanel.SetActive(true);
                }
                else
                {
                    ItemSelectionPanel.SetActive(false);
                }
            }
            else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
            {
                if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action == "withdraw"
                || RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action == "deposit")
                {
                    ItemSelectionPanel.SetActive(true);
                }
                else
                {
                    ItemSelectionPanel.SetActive(false);
                }
            }
            
        } else{
             ItemSelectionPanel.SetActive(false);
        }
    }

    void SetItemSelectedToNull(){
        if(GlobalVariables.GLOBAL_selectedObject != null){
            if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
            {
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action != "withdraw" && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action != "deposit")
                {
                    GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].itemSelected = null;
                }
            }
            else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
            {
                if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action != "withdraw" && RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action != "deposit")
                {
                    RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction,  GlobalVariables.GLOBAL_selectedIndex].itemSelected = null;
                }
            }
        }
    }
}
