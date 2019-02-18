using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTrigger : MonoBehaviour
{
    [SerializeField] GameObject robot;
    [SerializeField] string direction = "";

    void OnTriggerEnter(Collider other)
    {
        if (direction == "forward")
            robot.GetComponent<robot>().forwardTrigger = true;
        else
            robot.GetComponent<robot>().backwardTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (direction == "forward")
            robot.GetComponent<robot>().forwardTrigger = false;
        else
            robot.GetComponent<robot>().backwardTrigger = false;
    }
}
