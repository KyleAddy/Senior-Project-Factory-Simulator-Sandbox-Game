using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMine : MonoBehaviour
{
    public ItemSO oreType;
    [SerializeField] Material ironMat;
    [SerializeField] Material copperMat;


    // Start is called before the first frame update
    void Start()
    {
        if (oreType.itemName == "Iron Ore")
            GetComponent<Renderer>().material = ironMat;
        else if (oreType.itemName == "Copper Ore")
            GetComponent<Renderer>().material = copperMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
