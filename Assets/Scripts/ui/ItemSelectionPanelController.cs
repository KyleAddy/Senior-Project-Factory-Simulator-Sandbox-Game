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
        if(gameGlobal.GLOBAL_selectedObject != null){
            if(gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] == "withdraw" || gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] == "deposit"){
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
        if(gameGlobal.GLOBAL_selectedObject != null){
            if(gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] != "withdraw" && gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray[gameGlobal.GLOBAL_selectedIndex] != "deposit"){
                gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().itemSelectionArray[gameGlobal.GLOBAL_selectedIndex] = null;
            }
        }
    }
}
