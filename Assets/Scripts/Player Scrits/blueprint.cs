using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueprint : MonoBehaviour
{

    [SerializeField] Material blue;
    [SerializeField] Material red;

    [SerializeField] bool freeSpace = true;

    bool isCloseToPlayer = true;

    public GameObject prefabToPlace;
    public int invIndex;
    GameObject gameGlobalObj;
    GameObject player;

    private void Start()
    {
        gameGlobalObj = GameObject.Find("gameGlobal");
        player = GameObject.Find("gameGlobal");
    }

    // Update is called once per frame
    void Update()
    {
        moveToMouse();
        createObject();
        //TestDistToPlayer();
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
        if (Input.GetMouseButtonDown(0) && freeSpace && isCloseToPlayer)
        {
            Instantiate(prefabToPlace, transform.position, Quaternion.identity);
            gameGlobalObj.GetComponent<Inventory>().inventory[invIndex] = null;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().material = red;
        freeSpace = false;
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<MeshRenderer>().material = blue;
        freeSpace = true;
    }

    void TestDistToPlayer()
    {

        if(Vector3.Distance(player.transform.position, transform.position) <= 11 && freeSpace)
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
}
