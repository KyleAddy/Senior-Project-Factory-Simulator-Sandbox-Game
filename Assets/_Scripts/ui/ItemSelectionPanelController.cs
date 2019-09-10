using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectionPanelController : MonoBehaviour
{
    public GameObject ItemSelectionPanel;

    // Start is called before the first frame update
    void Start()
    {
        ItemSelectionPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ItemSelectionPanelCheck();
        SetItemSelectedToNull();
    }

    void ItemSelectionPanelCheck(){
        if(GlobalVariables.GLOBAL_selectedObject != null){
            if(GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] == "withdraw" || GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] == "deposit"){
                ItemSelectionPanel.SetActive(true);
            } else
            {
              ItemSelectionPanel.SetActive(false);   
            }
        } else{
             ItemSelectionPanel.SetActive(false);
        }
    }

    void SetItemSelectedToNull(){
        if(GlobalVariables.GLOBAL_selectedObject != null){
            if(GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] != "withdraw" && GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().progArray[GlobalVariables.GLOBAL_selectedIndex] != "deposit"){
                GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().itemSelectionArray[GlobalVariables.GLOBAL_selectedIndex] = null;
            }
        }
    }
}
