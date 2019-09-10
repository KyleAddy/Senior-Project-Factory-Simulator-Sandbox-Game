using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefineryAnimation : MonoBehaviour
{

    [SerializeField] GameObject gear;
    [SerializeField] GameObject smoke;

    bool smokeIsOn;

    public bool isAnimation = false;

    public float animationSpeed = 1;

    void Start()
    {
        smoke.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    void Animate()
    {
        if (isAnimation)
        {
            if (!smokeIsOn)
            {
                smoke.GetComponent<ParticleSystem>().enableEmission = true;
                smokeIsOn = true;
            }
            gear.transform.Rotate(Vector3.forward * (animationSpeed * 30 * Time.deltaTime));
        }
        else
        {
            if (smokeIsOn)
            {
                smoke.GetComponent<ParticleSystem>().enableEmission = false;
                smokeIsOn = false;
            }
        }
    }
}
