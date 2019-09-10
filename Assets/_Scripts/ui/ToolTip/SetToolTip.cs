using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToolTip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableToolTip(ItemSO item){
        GetComponent<ToolTipMovement>().SetPosition();
        gameObject.SetActive(true);
        GetComponent<ToolTipRecipeDisplay>().item = item;
    }

    public void DisableToolTip(){
        GetComponent<ToolTipRecipeDisplay>().item = null;
        gameObject.SetActive(false);
    }
}
