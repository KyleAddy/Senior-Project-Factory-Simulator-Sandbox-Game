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
        {
            GetComponent<robot>().runCode();
        }            

        //clears the programming array of the currently selected object
        if (Input.GetKeyDown(KeyCode.Backspace) && GlobalVariables.GLOBAL_selectedObject == GetComponent<LocationInitiation>().objectID)
        {
            for (int i = 0; i < GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram.Length; i++)
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[i].action = "none";
            GlobalVariables.GLOBAL_selectedIndex = 0;
        }
    }
}
