using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvCommandWindow : MonoBehaviour
{

    [SerializeField] GameObject progButton;

    // Start is called before the first frame update
    void Start()
    {
        setProgButton();
    }

    // Update is called once per frame
    void Update()
    {
        setProgButton();
    }

    void setProgButton()
    {
        if (gameGlobal.GLOBAL_selectedObject != null)
            if (gameGlobal.GLOBAL_selectedObject.CompareTag("robot"))
                progButton.SetActive(true);
        else
            progButton.SetActive(false);
    }
}
