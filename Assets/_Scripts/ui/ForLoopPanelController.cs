using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForLoopPanelController : MonoBehaviour
{
    public GameObject ForLoopPanel;
    public TextMeshProUGUI numToLoopDisplay; 

    // Start is called before the first frame update
    void Start()
    {
        ForLoopPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ForLoopPanelCheck();
        ForLoopPanelToNull();
    }

    void ForLoopPanelCheck()
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] == "for")
            {
                ForLoopPanel.SetActive(true);
                numToLoopDisplay.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[GlobalVariables.GLOBAL_selectedIndex].numToLoop.ToString();
            }
            else
            {
                ForLoopPanel.SetActive(false);
            }
        }
        else
        {
            ForLoopPanel.SetActive(false);
        }
    }

    void ForLoopPanelToNull()
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] != "for")
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[GlobalVariables.GLOBAL_selectedIndex].numToLoop = 1;
            }
        }
    }

    public void IncNumToLoop()
    {
        if  (Input.GetKey(KeyCode.LeftShift))
        {
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[GlobalVariables.GLOBAL_selectedIndex].numToLoop += 5;
        }
        else
        {
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[GlobalVariables.GLOBAL_selectedIndex].numToLoop++;
        }        
    }

    public void DecNumToLoop()
    {
        if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[GlobalVariables.GLOBAL_selectedIndex].numToLoop > 5 && Input.GetKey(KeyCode.LeftShift))
        {
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[GlobalVariables.GLOBAL_selectedIndex].numToLoop -= 5;
        }
        else if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[GlobalVariables.GLOBAL_selectedIndex].numToLoop > 1)
        {
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().loop[GlobalVariables.GLOBAL_selectedIndex].numToLoop--;
        }
    }
}