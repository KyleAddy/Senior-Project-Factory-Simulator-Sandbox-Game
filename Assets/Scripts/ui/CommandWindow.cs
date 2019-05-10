﻿using System.Collections;
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

    [SerializeField] GameObject invMenu;

    // Start is called before the first frame update
    void Start()
    {
        SetButton();
    }


    public void SetButton()
    {
        disableButtons();
        gameObject.SetActive(true);
        invMenu.SetActive(true);
        //pickUpButton.SetActive(false);
        //invButton.SetActive(false);

        if (gameGlobal.GLOBAL_selectedObject != null)
        {
            disableButtons();
            pickUpButton.SetActive(true);
            switch (globalGameObj.GetComponent<ui>().currentMenu)
            {
                case "inventory":
                    if (gameGlobal.GLOBAL_selectedObject != null)
                    {
                        InvScreenButtons();
                    }

                    break;
                case "program":
                    invButton.SetActive(true);
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
        switch (gameGlobal.GLOBAL_selectedObject.tag)
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
    }
}
