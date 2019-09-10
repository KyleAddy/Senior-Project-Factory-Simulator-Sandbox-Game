using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPasteProgButton : MonoBehaviour
{
    string[] copyProg = new string[25];
    int[] forLoop = new int[25];
    public string[] ifCondition = new string[25];
    public bool[] toggleIfConditionOutput = new bool[25];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 25; i++)//set the copyProg to empty
        {
            copyProg[i] = "";
        }

        for(int i = 0; i < 25; i++)//set the for loop to 1
        {
            forLoop[i] = 1;
        }

        for (int i = 0; i < 25; i++)
        {
            toggleIfConditionOutput[i] = false; //set the toggle if condition to false
        }
    }

    public void CopyProg()
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            for (int i = 0; i < 25; i++)
            {
                copyProg[i] = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[i];//program array
                forLoop[i] = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[i].numToLoop;//for loop data
                ifCondition[i] = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCondition[i];//if condition data
                toggleIfConditionOutput[i] = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().toggleIfConditionOutput[i];//toogle if condition data
            }

   
        }
    }

    public void PasteProg()
    {        
        if(GlobalVariables.GLOBAL_selectedObject != null)
        {
            for (int i = 0; i < 25; i++)
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[i] = copyProg[i];//program array
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[i].numToLoop = forLoop[i];//for loop data
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCondition[i] = ifCondition[i];//if condition data
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().toggleIfConditionOutput[i] = toggleIfConditionOutput[i];//toogle if condition data
            }
        }
    }
}
