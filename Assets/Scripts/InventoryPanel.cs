using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {

    public static bool updateInv;

	// Use this for initialization
	void Start () {
        updateInv = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (updateInv)
        {
            updateinventory();
            updateInv = false;
        }

        }

        void activateAllSlot()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
                    child.gameObject.SetActive(true);
        }
    }

    public void updateinventory()
    {
            //activateAllSlot();
            Transform[] allChildren = GetComponentsInChildren<Transform>(true);
            foreach (Transform child in allChildren)
            {
                if (child.gameObject.CompareTag("invSlot") && gameGlobal.GLOBAL_selectedObject != null)
                    if ((child.gameObject.GetComponent<SelectedObjInvSlot>().slotIndex + 1) > gameGlobal.GLOBAL_selectedObject.GetComponent<Inventory>().invSize)
                        child.gameObject.SetActive(false);
                    else
                        child.gameObject.SetActive(true);
            }
    }

	}
