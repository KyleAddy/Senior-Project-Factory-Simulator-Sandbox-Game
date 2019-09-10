using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IfConditionPanelController : MonoBehaviour
{
    public GameObject IfConditionPanel;
    public GameObject IFConditionDisplayText;
    [SerializeField] GameObject ifConditionToggleButton;
    [SerializeField] GameObject ifCountAmountPanel;
    [SerializeField] GameObject ifCountAmountTextDisplay;

    bool toggleCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        IfConditionPanel.SetActive(true);
        //UpdateIfConditionDisplayPanel();
    }

    // Update is called once per frame
    void Update()
    {
        IfConditionPanelCheck();
    }

    void IfConditionPanelCheck()
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] == "if" && !IfConditionPanel.activeSelf)
            {
                IfConditionPanel.SetActive(true);
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().toggleIfConditionOutput[GlobalVariables.GLOBAL_selectedIndex]){
                    ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "!";
                }
                else
                {
                    ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "";
                }
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCondition[GlobalVariables.GLOBAL_selectedIndex] == "" || GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCondition[GlobalVariables.GLOBAL_selectedIndex] == null)
                {
                    IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "";
                }                    
            }
            else if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] != "if" && IfConditionPanel.activeSelf)
            {
                IfConditionPanel.SetActive(false);
            }
        }
        else if (IfConditionPanel.activeSelf)
        {
            IfConditionPanel.SetActive(false);
        }
    }

    public void SetIfCondition(string condition)
    {
        GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCondition[GlobalVariables.GLOBAL_selectedIndex] = condition;
    }    

    public void SetIfConditionDisplay(GameObject text)
    {
        IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = text.GetComponent<TextMeshProUGUI>().text;
    }

    public void ToggleConditionOutputButton()
    {
        if(GlobalVariables.GLOBAL_selectedObject != null)
        {
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().toggleIfConditionOutput[GlobalVariables.GLOBAL_selectedIndex] = !GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().toggleIfConditionOutput[GlobalVariables.GLOBAL_selectedIndex];
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().toggleIfConditionOutput[GlobalVariables.GLOBAL_selectedIndex])
            {
                ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "!";
            }
            else
            {
                ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void UpdateIfConditionDisplayPanel()
    {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().toggleIfConditionOutput[GlobalVariables.GLOBAL_selectedIndex])
            {
                ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "!";
            }
            else
            {
                ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "";
            }        

        ifCountAmountPanel.SetActive(false);//disable the If count panel
        if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCondition[GlobalVariables.GLOBAL_selectedIndex] == "" || GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCondition[GlobalVariables.GLOBAL_selectedIndex] == null)
        {
            IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "";
        }
        else
        {
            switch (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCondition[GlobalVariables.GLOBAL_selectedIndex])
            {
                case "invFull":
                    IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "Robot Inventory Full";
                    break;

                case "invEmpty":
                    IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "Robot Inventory Empty";
                    break;

                case "AdjacentInvFull":
                    IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "Adjacent Inventory Full";
                    break;

                case "AdjacentInvEmpty":
                    IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "Adjacent Inventory Empty";
                    break;

                case "RobotXEmptySlots":
                    IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = " Robot has X Amount of Empty Slots";
                    ifCountAmountPanel.SetActive(true);
                    break;

                case "AdjacentInvXEmptySlots":
                    IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "Adjacent Inventory has X Amount of Empty Inventory Slots";
                    ifCountAmountPanel.SetActive(true);
                    break;
            }
        }


        UpdateifCountAmountDisplay();
    }

    public void IncIfCountAmount()
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex] <= 20  && Input.GetKey(KeyCode.LeftShift))
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex] += 5;
            }
            else if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex] <= 24)
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex]++;
            }
            UpdateifCountAmountDisplay();
        }
    }

    public void DecIfCountAmount()
    {
        if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex] >= 5 && Input.GetKey(KeyCode.LeftShift))
        {
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex] -= 5;
        }
        else if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex] > 0)
        {
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex]--;
        }
        UpdateifCountAmountDisplay();
    }

    public void UpdateifCountAmountDisplay()
    {
        ifCountAmountTextDisplay.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().ifCountAmount[GlobalVariables.GLOBAL_selectedIndex].ToString();
    }
}