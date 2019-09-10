using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public bool rotate_X_Axis = false;
    public bool rotate_Y_Axis = false;
    public bool rotate_Z_Axis = false;

    public float x_RotateSpeed = 5;
    public float Y_RotateSpeed = 5;
    public float Z_RotateSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate(){
        if (rotate_X_Axis){
            transform.Rotate(x_RotateSpeed * Time.deltaTime,0,0);
        }
        if (rotate_Y_Axis){
            transform.Rotate(0,Y_RotateSpeed * Time.deltaTime,0);
        }
        if (rotate_Z_Axis){
            transform.Rotate(0,0,Z_RotateSpeed * Time.deltaTime);
        }
        
    }
}
