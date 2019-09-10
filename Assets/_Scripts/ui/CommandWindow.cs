using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandWindow : MonoBehaviour
{
    [SerializeField] GameObject globalGameObj;
    [SerializeField] GameObject progButton;
    [SerializeField] GameObject refineryButton;
    [SerializeField] GameObject assemblerButton;
    [SerializeField] GameObject invButton;
    [SerializeField] GameObject pickUpButton;
    [SerializeField] GameObject runRobotCodeButton;
    [SerializeField] GameObject CopyPasteButton;

    [SerializeField] GameObject invMenu;

    [SerializeField] GameEvent EnableInventoryWindow;
    [SerializeField] GameEvent EnableProgrammingWindow;
    [SerializeField] GameEvent EnableRefineryWindow;
    [SerializeField] GameEvent EnableAssemblerWindow;
    [SerializeField] GameEvent PickUpItem;
    [SerializeField] GameEvent EnableEscapeWindow;

    // Start is called before the first frame update
    void Start()
    {
        globalGameObj = GlobalVariables.gameManager;
        SetButton();
    }


    public void SetButton()
    {
        disableButtons();
        gameObject.SetActive(true);
        invMenu.SetActive(true);

        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            disableButtons();
            pickUpButton.SetActive(true);
            if (globalGameObj == null)
            {
                globalGameObj = GlobalVariables.gameManager;
            }
            switch (globalGameObj.GetComponent<ui>().currentMenu)
            {
                case "inventory":
                    if (GlobalVariables.GLOBAL_selectedObject != null)
                    {
                        InvScreenButtons();
                    }

                    break;
                case "program":
                    invButton.SetActive(true);
                    runRobotCodeButton.SetActive(true);
                    CopyPasteButton.SetActive(true);
                    break;

                case "refinery":
                    invButton.SetActive(true);
                    break;

                case "assembler":
                    invButton.SetActive(true);
                    break;
            }
        }
    }

    void InvScreenButtons()
    {
        disableButtons();
        pickUpButton.SetActive(true);
        invMenu.SetActive(true);
        switch (GlobalVariables.GLOBAL_selectedObject.tag)
        {
            case "robot":
                progButton.SetActive(true);
                break;

            case "refinery":
                refineryButton.SetActive(true);
                break;

            case "assembler":
                assemblerButton.SetActive(true);
                break;
        }
    }

    void disableButtons()
    {
        //print("buttons disabled");
        invButton.SetActive(false);
        progButton.SetActive(false);
        refineryButton.SetActive(false);
        assemblerButton.SetActive(false);
        invMenu.SetActive(false);
        pickUpButton.SetActive(false);
        runRobotCodeButton.SetActive(false);
        CopyPasteButton.SetActive(true);
    }

    public void RunRobotCode()
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.tag == "robot")
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().runCode();
            }
        }
    }

    public void RaiseEnableInventoryWindowEvent()
    {
        EnableInventoryWindow.Raise();
    }
    public void RaiseEnableProgrammingWindowEvent()
    {
        EnableProgrammingWindow.Raise();
    }
    public void RaiseEnableRefineryWindowEvent()
    {
        EnableRefineryWindow.Raise();
    }
    public void RaiseEnableAssemblerWindowEvent()
    {
        EnableAssemblerWindow.Raise();
    }
    public void RaisePickUpItemEvent()
    {
        PickUpItem.Raise();
    }
    public void RaiseEnableEscapeMenu()
    {
        EnableEscapeWindow.Raise();
    }
}
