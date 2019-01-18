using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{

    [SerializeField] GameObject gameGlobalObj;

    void OnMouseDown()
    {
        gameGlobal.GLOBAL_selectedObject = GetComponent<LocationInitiation>().objectID;
        ObjType();
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
    }
}
