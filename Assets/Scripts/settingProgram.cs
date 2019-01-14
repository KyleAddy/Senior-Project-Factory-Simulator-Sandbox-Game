using UnityEngine;

public class settingProgram : MonoBehaviour {

	public string buttonType;
	
	// Update is called once per frame
	void Update () {
	}
		
	public void setAction(){
		gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray [gameGlobal.GLOBAL_selectedIndex] = buttonType;
		gameGlobal.GLOBAL_selectedIndex++;
	}
}
