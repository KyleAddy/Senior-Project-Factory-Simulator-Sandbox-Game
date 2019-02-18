using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{

    [SerializeField] GameObject gameGlobalObj;

    private void Start()
    {
        gameGlobalObj = GameObject.Find("gameGlobal");
    }

    void OnMouseDown()
    {
        if (gameGlobalObj.GetComponent<ui>().currentMenu == "")
        {
            gameGlobal.GLOBAL_selectedObject = GetComponent<LocationInitiation>().objectID;
            ObjType();
        }
    }

    void ObjType()
    {
        if (gameObject.CompareTag("robot"))
        {
            gameGlobalObj.GetComponent<ui>().EnableProgMenu();
        }
        else if (gameObject.CompareTag("storage"))
        {
            gameGlobalObj.GetComponent<ui>().EnableInvMenu();
        }
        else if (gameObject.CompareTag("refinery"))
        {
            gameGlobalObj.GetComponent<ui>().EnableRefineryMenu();
        }
        else if (gameObject.CompareTag("assembler"))
        {
            gameGlobalObj.GetComponent<ui>().EnableAssemblerMenu();
        }
    }
}
