using UnityEngine;

public class settingProgram : MonoBehaviour {

	public string buttonType;
		
	public void setAction(){
        
        GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] = buttonType;
        if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] != "withdraw" 
            && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] != "deposit"
            && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] != "for"
            && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] != "if"
            && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] != "")
        {
            //default the if condition
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCondition[GlobalVariables.GLOBAL_selectedIndex] = "";
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().toggleIfConditionOutput[GlobalVariables.GLOBAL_selectedIndex] = false;
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex] = 1;

            GlobalVariables.GLOBAL_selectedIndex++;//go to the next programming slot
        }
        GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().isRunning = false;
    }
}
