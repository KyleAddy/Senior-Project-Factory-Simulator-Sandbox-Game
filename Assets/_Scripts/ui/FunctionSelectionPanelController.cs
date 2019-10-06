using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionSelectionPanelController : MonoBehaviour
{

    [SerializeField] GameObject functionSelectionPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckFunctionSelecionPanelController();
    }

    void CheckFunctionSelecionPanelController()
    {
        if(GlobalVariables.GLOBAL_selectedObject == null)
        {
            return;
        }

        if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
        {
            functionSelectionPanel.SetActive(true);
        }
        else
        {
            functionSelectionPanel.SetActive(false);
        }
    }

    public void SetSelectedFunction(int selection)
    {
        RobotPlayerFunctions.selectedFunction = selection;
        GlobalVariables.GLOBAL_selectedIndex = 0;
    }

}
