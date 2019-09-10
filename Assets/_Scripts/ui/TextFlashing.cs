using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlashing : MonoBehaviour
{
    [SerializeField] GameObject SpaceText;
    // Start is called before the first frame update
    void Start()
    {
        SpaceText.GetComponent<Image>().canvasRenderer.SetAlpha(1f);
        setToZero();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setToOne()
    {
        if (gameObject.activeSelf)
        {
            ExtensionMethod.CrossFadeAlphaWithCallBack(SpaceText.GetComponent<Image>(), 1f, 1f, delegate { });
        }
        Invoke("setToZero",1.1f);
    }

    void setToZero()
    {
        if (gameObject.activeSelf)
        {
            ExtensionMethod.CrossFadeAlphaWithCallBack(SpaceText.GetComponent<Image>(), 0.001f, 1f, delegate { });
        }
        Invoke("setToOne", 1.1f);
    }
}
