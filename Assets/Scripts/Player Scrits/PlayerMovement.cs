using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int directionFacing = 0;
    public Rigidbody rb;
    public float movementSpeed = 2;

    public bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }
        SetAnimation();
    }

    void FixedUpdate()
    {
        PlayerMovementInput();
        SetPlayerDirection();
        if (isMoving)
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * movementSpeed);
    }

    void PlayerMovementInput()
    {
        if (Input.GetKey(KeyCode.W)) //if holding up arrow
        {
            isMoving = true;
            if (Input.GetKey(KeyCode.D)) // holding up and right
            {
                directionFacing = 45;
            }
            else if (Input.GetKey(KeyCode.A))// holding up and left
            {
                directionFacing = 315;
            }
            else
            {
                directionFacing = 0; // holding jsut up
            }
        }
        else if (Input.GetKey(KeyCode.S)) // if holding down arrow
        {
            isMoving = true;
            if (Input.GetKey(KeyCode.D)) // holding down and right
            {
                directionFacing = 135;
            }
            else if (Input.GetKey(KeyCode.A)) // holding down and left
            {
                directionFacing = 225;
            }
            else
            {
                directionFacing = 180; // holding just down
            }
        }
        else if (Input.GetKey(KeyCode.D)) // holding just right
        {
            isMoving = true;
            directionFacing = 90;
        }
        else if (Input.GetKey(KeyCode.A)) // holding just left
        {
            isMoving = true;
            directionFacing = 270;
        }
        else
        {
            isMoving = false;
        }

    }

    void SetPlayerDirection()
    {
        transform.rotation = Quaternion.AngleAxis(directionFacing, Vector3.up); ;
    }

    void SetAnimation()
    {
        if (isMoving)
        {
            transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", movementSpeed);
        }
        else
        {
            transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", 0);
        }
           
    }
}