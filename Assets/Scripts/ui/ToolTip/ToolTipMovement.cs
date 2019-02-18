using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipMovement : MonoBehaviour
{
    
    public float offset = 150;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //SetPosition();

        if (Input.GetKeyDown(KeyCode.N)){

            //Debug.Log("mouse: "+ Input.mousePosition);
            //Debug.Log("panel: "+transform.position);
        }
    }

    public void SetPosition(){
        //transform.position = Input.mousePosition + offset;

        //Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector2(worldMousePos.x, worldMousePos.y);
    }
}
