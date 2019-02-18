using UnityEngine;

public class settingProgram : MonoBehaviour {

	public string buttonType;
	
	// Update is called once per frame
	void Update () {
	}
		
	public void setAction(){
        if (buttonType == "clearBlock") {
            gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] = "none";
        }
        else
        {
            gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] = buttonType;
            if (gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] != "withdraw" && gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] != "deposit")
                gameGlobal.GLOBAL_selectedIndex++;
        }
	}
}
