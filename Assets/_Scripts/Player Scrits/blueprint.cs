﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueprint : MonoBehaviour
{
    [SerializeField] LayerMask canCollidWith;
    [SerializeField] Material blue;
    [SerializeField] Material red;

    int numberOfCollisions = 0;

    bool isCloseToPlayer = true;

    public GameObject prefabToPlace;
    public int invIndex;
    GameObject gameGlobalObj;
    GameObject player;

    int numOfChildren;

    private void Start()
    {
        gameGlobalObj = GameObject.Find(ConstVariables.gameManagerName);
        player = GameObject.Find(ConstVariables.playerName);
        int numOfChildren = transform.childCount;
        numOfChildren--;
    }

    // Update is called once per frame
    void Update()
    {
        moveToMouse();
        createObject();
        cancelPlacement();
        SetMaterial();
        //TestDistToPlayer();
    }

    void SetMaterial()
    {
        if(numberOfCollisions != 0) //set material red
        {
            if (GetComponent<MeshRenderer>() != null)
                GetComponent<MeshRenderer>().material = red;
            for (int i = 0; i <= (transform.childCount - 1); i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<MeshRenderer>().sharedMaterial = red;
            }
        }
        else //set material blue
        {
            if (GetComponent<MeshRenderer>() != null)
                GetComponent<MeshRenderer>().material = blue;
            for (int i = 0; i <= (transform.childCount - 1); i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<MeshRenderer>().sharedMaterial = blue;
            }
        }
    }

    void moveToMouse()
    {
        Vector3 pos;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 100);
        pos = hit.point;
        pos.y = .5f;
        pos.x = Mathf.RoundToInt(pos.x);
        pos.z = Mathf.RoundToInt(pos.z);
        transform.position = pos;
    }

    void createObject()
    {
        if (Input.GetMouseButtonDown(0) && numberOfCollisions == 0 && isCloseToPlayer)
        {
            Instantiate(prefabToPlace, transform.position, Quaternion.identity);
            gameGlobalObj.GetComponent<Inventory>().inventory[invIndex] = null;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != canCollidWith){
            numberOfCollisions++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != canCollidWith)
        {
            numberOfCollisions--;
        }
    }

    void TestDistToPlayer()
    {

        if(Vector3.Distance(player.transform.position, transform.position) <= 11)
        {
            GetComponent<MeshRenderer>().material = blue;
            isCloseToPlayer = true;
        }
        else
        {
            GetComponent<MeshRenderer>().material = red;
            isCloseToPlayer = false;
        }
    }

    void cancelPlacement(){
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(2)){
            Destroy(gameObject);
        }
    }
}
