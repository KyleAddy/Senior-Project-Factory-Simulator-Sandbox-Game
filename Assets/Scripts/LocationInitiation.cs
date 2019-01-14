using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInitiation : MonoBehaviour {

    public GameObject objectID;

    // Use this for initialization
    void Start () {
        objectID = (GameObject)gameObject;
        gameGlobal.GLOBAL_grid[(int)transform.position.x, (int)transform.position.z] = objectID;
    }
}
