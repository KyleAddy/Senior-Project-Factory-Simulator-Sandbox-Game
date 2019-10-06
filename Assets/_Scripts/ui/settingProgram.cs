using UnityEngine;

public class settingProgram : MonoBehaviour {

	public string buttonType;

    [SerializeField] GameEvent disableProgramSubmenus;
    [SerializeField] GameEvent itemSelectionMenuEvent;
    [SerializeField] GameEvent forLoopMenuEvent;
    [SerializeField] GameEvent ifStatementMenuEvent;


    public void setAction(){

        if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>())
        {
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action = buttonType;
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action != "withdraw"
                && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action != "deposit"
                && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action != "for"
                && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action != "if"
                && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action != "")
            {
                //default the if condition
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCondition = "";
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput = false;
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount = 1;

                GlobalVariables.GLOBAL_selectedIndex++;//go to the next programming slot
            }
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().isRunning = false;
        }
        else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
        {
            RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action = buttonType;
            if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action != "withdraw"
                && RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action != "deposit"
                && RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action != "for"
                && RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action != "if"
                && RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action != "")
            {
                //default the if condition
                RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCondition = "";
                RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput = false;
                RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount = 1;

                GlobalVariables.GLOBAL_selectedIndex++;//go to the next programming slot
            }
        }
    }
}
