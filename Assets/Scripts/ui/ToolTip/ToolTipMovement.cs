using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipMovement : MonoBehaviour
{
    
    [SerializeField]float offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();

        if (Input.GetKeyDown(KeyCode.N)){

            Debug.Log("mouse X: "+ Input.mousePosition.x);
            Debug.Log("mouse Y: "+ Input.mousePosition.y);
            //Debug.Log("mouse Z: "+ Input.mousePosition.z);
            //Debug.Log("panel: "+transform.position);
        }
    }

    public void SetPosition(){
        offset = Screen.width/8;
        Vector3 toolTipPos;
        toolTipPos = Input.mousePosition;
        if (Input.mousePosition.x > Screen.width-(Screen.width/5)){
            toolTipPos.x -= offset;
        }else {
            toolTipPos.x += offset;
        }
        if (Input.mousePosition.y > (Screen.height/4)){
            toolTipPos.y -= offset;
        }else {
            toolTipPos.y += offset;
        }
        
        
        transform.position = toolTipPos;
    }
}
