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
            if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
            {
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action == "if" && !IfConditionPanel.activeSelf)
                {
                    IfConditionPanel.SetActive(true);
                    if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput)
                    {
                        ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "!";
                    }
                    else
                    {
                        ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCondition == "" || GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCondition == null)
                    {
                        IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "";
                    }
                }
                else if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].action != "if" && IfConditionPanel.activeSelf)
                {
                    IfConditionPanel.SetActive(false);
                }
            }
            else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
            {
                if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action == "if" && !IfConditionPanel.activeSelf)
                {
                    IfConditionPanel.SetActive(true);
                    if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput)
                    {
                        ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "!";
                    }
                    else
                    {
                        ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCondition == "" || RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCondition == null)
                    {
                        IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "";
                    }
                }
                else if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].action != "if" && IfConditionPanel.activeSelf)
                {
                    IfConditionPanel.SetActive(false);
                }
            }

        }
        else if (IfConditionPanel.activeSelf)
        {
            IfConditionPanel.SetActive(false);
        }
    }

    public void SetIfCondition(string condition)
    {
        if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
        {
            GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCondition = condition;
        }
        else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
        {
            RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCondition = condition;
        }
    }    

    public void SetIfConditionDisplay(GameObject text)
    {
        IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = text.GetComponent<TextMeshProUGUI>().text;
    }

    public void ToggleConditionOutputButton()
    {
        if(GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput = !GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput;
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput)
                {
                    ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "!";
                }
                else
                {
                    ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "";
                }
            }
            else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
            {
                RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput = !RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput;
                if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput)
                {
                    ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "!";
                }
                else
                {
                    ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "";
                }
            }

        }
    }

    public void UpdateIfConditionDisplayPanel()
    {
        if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
        {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput)
            {
                ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "!";
            }
            else
            {
                ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "";
            }
        }
        else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
        {
            if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].toggleIfConditionOuput)
            {
                ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "!";
            }
            else
            {
                ifConditionToggleButton.GetComponent<TextMeshProUGUI>().text = "";
            }
        }


        ifCountAmountPanel.SetActive(false);//disable the If count panel

        if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
        {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCondition == "" || GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCondition == null)
            {
                IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "";
            }
            else
            {
                switch (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCondition)
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
        }
        else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
        {
            if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCondition == "" || RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCondition == null)
            {
                IFConditionDisplayText.GetComponent<TextMeshProUGUI>().text = "";
            }
            else
            {
                switch (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCondition)
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
        }



        UpdateifCountAmountDisplay();
    }

    public void IncIfCountAmount()
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
            {
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount <= 20 && Input.GetKey(KeyCode.LeftShift))
                {
                    GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount += 5;
                }
                else if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount <= 24)
                {
                    GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount++;
                }
            }
            else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
            {
                if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount <= 20 && Input.GetKey(KeyCode.LeftShift))
                {
                    RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount += 5;
                }
                else if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount <= 24)
                {
                    RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount++;
                }
            }

            UpdateifCountAmountDisplay();
        }
    }

    public void DecIfCountAmount()
    {
        if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
        {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount >= 5 && Input.GetKey(KeyCode.LeftShift))
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount -= 5;
            }
            else if (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount > 0)
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount--;
            }
        }
        else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
        {
            if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount >= 5 && Input.GetKey(KeyCode.LeftShift))
            {
                RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount -= 5;
            }
            else if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount > 0)
            {
                RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount--;
            }
        }

        UpdateifCountAmountDisplay();
    }

    public void UpdateifCountAmountDisplay()
    {
        if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
        {
            ifCountAmountTextDisplay.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[GlobalVariables.GLOBAL_selectedIndex].ifCountAmount.ToString();
        }
        else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
        {
            ifCountAmountTextDisplay.GetComponent<TextMeshProUGUI>().text = RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, GlobalVariables.GLOBAL_selectedIndex].ifCountAmount.ToString();
        }
    }
}