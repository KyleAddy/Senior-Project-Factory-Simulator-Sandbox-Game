using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour {

    public GameObject commandWindow;
    public GameObject progmenu;
    public GameObject invMenu;
    public GameObject refineryMenu;
    public GameObject assemblerMenu;
    public GameObject EscapeMenu;
    public string currentMenu;

    [SerializeField] GameObject toolTip;

	// Use this for initialization
	void Start () {
        CloseGUI();
    }
	 
	// Update is called once per frame
	void Update () {
        UserInput();
    }

    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentMenu == "")
            {
                currentMenu = "EscapeMenu";
                EscapeMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                CloseGUI();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentMenu == "EscapeMenu")
            {
                return;
            }
            if (currentMenu == "")
                EnableInvMenu();
            else if (currentMenu != "")
                CloseGUI();
        }

    }
    public void CloseGUI()
    {
        DisableAllMenus();
        GlobalVariables.GLOBAL_selectedObject = null;
        GlobalVariables.GLOBAL_selectedIndex = 0;
    }

    void DisableAllMenus()
    {

        progmenu.SetActive(false);
        invMenu.SetActive(false);
        refineryMenu.SetActive(false);
        assemblerMenu.SetActive(false);
        commandWindow.SetActive(false);
        currentMenu = "";
        toolTip.SetActive(false);
        EscapeMenu.SetActive(false);
    }

    public void EnableProgMenu()
    {
        DisableAllMenus();
        progmenu.SetActive(true);
        currentMenu = "program";
        commandWindow.GetComponent<CommandWindow>().SetButton();
    }

    public void EnableInvMenu()
    {
        DisableAllMenus();
        invMenu.SetActive(true);
        currentMenu = "inventory";
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            invMenu.transform.Find("selectedInv").gameObject.SetActive(true);
            invMenu.transform.Find("itemDescriptionPanel").gameObject.SetActive(false);
            invMenu.transform.Find("playerCraftingMenu").gameObject.SetActive(false);
            invMenu.transform.Find("selectedInv").gameObject.GetComponent<SelectedInventoryPanel>().updateinventory();
            invMenu.transform.Find("playerInv").gameObject.GetComponent<PlayerInventoryPanel>().updateinventory();
        }
        else
        {
            invMenu.transform.Find("selectedInv").gameObject.SetActive(false);
            invMenu.transform.Find("playerCraftingMenu").gameObject.SetActive(true);
        }

        commandWindow.GetComponent<CommandWindow>().SetButton();
    }

    public void EnableRefineryMenu()
    {
        DisableAllMenus();
        currentMenu = "refinery";
        refineryMenu.SetActive(true);
        commandWindow.GetComponent<CommandWindow>().SetButton();
    }
    public void EnableAssemblerMenu()
    {
        DisableAllMenus();
        currentMenu = "assembler";
        assemblerMenu.SetActive(true);
        commandWindow.GetComponent<CommandWindow>().SetButton();
    }

}
