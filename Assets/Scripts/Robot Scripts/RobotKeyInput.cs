using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotKeyInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        keyCode();
	}

    void keyCode()
    {
        //run all robots programs
        if (Input.GetKeyDown(KeyCode.Return))
            GetComponent<robot>().isRunning = true;

        //clears the programming array of the currently selected object
        if (Input.GetKeyDown(KeyCode.Backspace) && gameGlobal.GLOBAL_selectedObject == GetComponent<LocationInitiation>().objectID)
        {
            for (int i = 0; i < gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray.Length; i++)
                gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[i] = "none";
            gameGlobal.GLOBAL_selectedIndex = 0;
        }
    }
}
