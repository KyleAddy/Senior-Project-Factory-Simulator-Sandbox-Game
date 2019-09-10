using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CommandConsole : MonoBehaviour
{
    [SerializeField] ItemSO empty;
    [SerializeField] ItemSO robot;
    [SerializeField] ItemSO refinery;
    [SerializeField] ItemSO assembler;
    [SerializeField] ItemSO ironIngot;
    [SerializeField] ItemSO copperIngot;
    [SerializeField] ItemSO storageBox;

    [SerializeField] GameEvent saveGameEvent;
    [SerializeField] int maxNumberOfWords;
    [SerializeField] GameObject inputFeild;
    [SerializeField] GameObject[] outputLines;
    [SerializeField] GameObject console;

    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GlobalVariables.gameManager;
        for (int i = 0; i < outputLines.Length; i++)
        {
            outputLines[i].GetComponent<TextMeshProUGUI>().text = "";
        }

        console.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (console.activeSelf)
            {
                console.SetActive(false);
            }
            else if (!console.activeSelf)
            {
                console.SetActive(true);
            }
        }
    }

    public void EnterCommand()
    {
        
        string input = inputFeild.GetComponent<Text>().text;
        string[] words = new string[maxNumberOfWords];
        if(input.Length == 0)
        {
            return;
        }

        int wordCount = 0;
        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] == ' ' && wordCount < (maxNumberOfWords-1))
            {
                wordCount++;
                continue;
            }

            words[wordCount] += input[i];
        }

            
        switch (words[0])
        {
            case "give":
                GiveCommand(ref words);
                break;

            case "clear":
                gameManager.GetComponent<gameGlobal>().ClearInventory();
                PrintToConsole("Inventory Cleared");
                break;

            case "save":
                PrintToConsole("Saving Game");
                saveGameEvent.Raise();
                break;

            case "quit":
                PrintToConsole("Quiting Game");
                Application.Quit();
                break;

            default:
                PrintToConsole("Unkown Command");
                break;
        }
        
    }

    void GiveCommand(ref string[] words)
    {
        int quantity = 0;
        bool quantityEntered = Int32.TryParse(words[2], out quantity);
        if (!quantityEntered)
        {
            PrintToConsole("Unkown Quantity");
            return;
        }

        switch (words[1])
        {
            case "robot":
                gameManager.GetComponent<gameGlobal>().GivePlayerItem(robot, quantity);
                PrintToConsole("Gave Player robot, quantitiy: " + quantity);
                break;

            case "refinery":
                gameManager.GetComponent<gameGlobal>().GivePlayerItem(refinery, quantity);
                PrintToConsole("Gave Player refinery, quantitiy: " + quantity);
                break;

            case "assembler":
                gameManager.GetComponent<gameGlobal>().GivePlayerItem(assembler, quantity);
                PrintToConsole("Gave Player assembler, quantitiy: " + quantity);
                break;

            case "ironingot":
                gameManager.GetComponent<gameGlobal>().GivePlayerItem(ironIngot, quantity);
                PrintToConsole("Gave Player iron ingot, quantitiy: " + quantity);
                break;

            case "copperingot":
                gameManager.GetComponent<gameGlobal>().GivePlayerItem(copperIngot, quantity);
                PrintToConsole("Gave Player copper ingot, quantitiy: " + quantity);
                break;

            case "storagebox":
                gameManager.GetComponent<gameGlobal>().GivePlayerItem(storageBox, quantity);
                PrintToConsole("Gave Player storage box, quantitiy: " + quantity);
                break;

            default:
                PrintToConsole("Unkown Item");
                break;
        }
    }

    void PrintToConsole(string output)
    {
        int lineToPrintTo = 0;
        for(lineToPrintTo = 0; lineToPrintTo < outputLines.Length-1; lineToPrintTo++)
        {
            if(outputLines[lineToPrintTo].GetComponent<TextMeshProUGUI>().text == "")
            {
                break;
            }
        }

        if(lineToPrintTo == outputLines.Length - 1 && outputLines[outputLines.Length - 1].GetComponent<TextMeshProUGUI>().text != "")
        {
            IterateOutputText();
        }

        outputLines[lineToPrintTo].GetComponent<TextMeshProUGUI>().text = output;
    }
    void IterateOutputText()
    {
        for (int i = 0; i < outputLines.Length-1; i++)
        {
            outputLines[i].GetComponent<TextMeshProUGUI>().text = outputLines[(i + 1)].GetComponent<TextMeshProUGUI>().text;
        }
    }
}
