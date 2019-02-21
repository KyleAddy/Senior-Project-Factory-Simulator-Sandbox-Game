using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblerAnimation : MonoBehaviour
{
    [SerializeField] GameObject gear1;
    [SerializeField] GameObject gear2;
    [SerializeField] GameObject gear3;

    public bool isAnimation = false;

    public float animationSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpinGears();
    }

    void SpinGears(){
        if (isAnimation){
            gear1.transform.Rotate ( Vector3.forward * (animationSpeed * 10 * Time.deltaTime) );
            gear2.transform.Rotate ( Vector3.forward * (animationSpeed * 30  * Time.deltaTime ) );
            gear3.transform.Rotate ( Vector3.forward * (animationSpeed * 60 * Time.deltaTime ) );
        }
    }
}
