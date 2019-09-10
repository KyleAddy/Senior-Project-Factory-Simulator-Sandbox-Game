using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindyDustParticalLocation : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int xOffSet;
    [SerializeField] int zOffSet;
    [SerializeField] int yValue;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + xOffSet, yValue, player.transform.position.z + zOffSet);
    }
}
