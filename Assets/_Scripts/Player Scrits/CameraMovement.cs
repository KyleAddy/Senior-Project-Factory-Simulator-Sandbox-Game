using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject player;
    Vector3 tempPos;

    public float cameraHeight = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(ConstVariables.playerName);
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = player.transform.position;
        tempPos.y = cameraHeight;
        tempPos.z -= 2;
        transform.position = tempPos;
    }
}
