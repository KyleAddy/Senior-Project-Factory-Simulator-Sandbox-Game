using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInitiation : MonoBehaviour {

    public GameObject objectID;
    public bool loadedIn = false;

    // Use this for initialization
    void Start () {        
        objectID = (GameObject)gameObject;
        if (!loadedIn)
        {
            GlobalVariables.GLOBAL_grid[(int)transform.position.x, (int)transform.position.z] = objectID;
        }
    }
}
