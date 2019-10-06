using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableProgrammingButtons : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttonsToDisableDuringComputerInteraction;
    bool currentValue = false;

    void Start()
    {
        SetButtonsActiveValue(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot") && !currentValue)
            {
                SetButtonsActiveValue(true);
            }
            else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer") && currentValue)
            {
                SetButtonsActiveValue(false);
            }
        }
    }

    private void SetButtonsActiveValue(bool value)
    {
        for (int i = 0; i < buttonsToDisableDuringComputerInteraction.Length; i++)
        {
            buttonsToDisableDuringComputerInteraction[i].SetActive(value);
        }
        currentValue = value;
    }
}
