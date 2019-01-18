﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour {

    public GameObject progmenu;
    public GameObject invMenu;
    public string currentMenu;
	// Use this for initialization
	void Start () {
        DisableAllMenus();
	}
	 
	// Update is called once per frame
	void Update () {

        UserInput();
    }

    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableAllMenus();
            gameGlobal.GLOBAL_selectedObject = null;
            gameGlobal.GLOBAL_selectedIndex = 0;
        }

        if (Input.GetKeyDown(KeyCode.P))
            EnableProgMenu();

        if (Input.GetKeyDown(KeyCode.I))
            EnableInvMenu();

    }

    void DisableAllMenus()
    {

        progmenu.SetActive(false);
        invMenu.SetActive(false);
        currentMenu = "";
    }

    public void EnableProgMenu()
    {
        DisableAllMenus();
        progmenu.SetActive(true);
        currentMenu = "program";
    }

    public void EnableInvMenu()
    {
        DisableAllMenus();
        invMenu.SetActive(true);
        currentMenu = "inventory";
        if (gameGlobal.GLOBAL_selectedObject != null)
        {
            invMenu.transform.Find("selectedInv").gameObject.SetActive(true);
            invMenu.transform.Find("selectedInv").gameObject.GetComponent<SelectedInventoryPanel>().updateinventory();
            invMenu.transform.Find("playerInv").gameObject.GetComponent<PlayerInventoryPanel>().updateinventory();
        }
        else
        {
            invMenu.transform.Find("selectedInv").gameObject.SetActive(false);
        }
    }

}