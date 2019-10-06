using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPasteProgButton : MonoBehaviour
{
    public struct codeAction
    {
        //program action
        public string action;

        //item selection
        public string itemSelected;

        //for loop
        public int numToLoop;
        public int numLeftToLoop;

        //if statement
        public string ifCondition;
        public bool toggleIfConditionOuput;
        public int ifCountAmount;
    }

    codeAction[] copyProgram = new codeAction[25];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 25; i++)//set the copyProg to empty
        {
            copyProgram[i].action = "";
            copyProgram[i].numToLoop = 1;
            copyProgram[i].toggleIfConditionOuput = false;
        }
    }

    public void CopyProg()
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            for (int i = 0; i < 25; i++)
            {
                copyProgram[i].action = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[i].action;
                copyProgram[i].numToLoop = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[i].numToLoop;
                copyProgram[i].ifCondition = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[i].ifCondition;
                copyProgram[i].toggleIfConditionOuput = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[i].toggleIfConditionOuput;
            }
        }
    }

    public void PasteProg()
    {        
        if(GlobalVariables.GLOBAL_selectedObject != null)
        {
            for (int i = 0; i < 25; i++)
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[i].action = copyProgram[i].action;
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[i].numToLoop = copyProgram[i].numToLoop;
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[i].ifCondition = copyProgram[i].ifCondition;
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[i].toggleIfConditionOuput = copyProgram[i].toggleIfConditionOuput;
            }
        }
    }
}
