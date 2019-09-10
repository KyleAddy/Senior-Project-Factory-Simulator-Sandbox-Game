using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int directionFacing = 0;
    public Rigidbody rb;
    public float movementSpeed = 2;
    public float runningMultiplyer = 50f;

    public bool isMoving = false;
    public bool isRunning = false;
    public int frontColliderTrigger = 0;

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
        {
            if (isRunning)
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * (movementSpeed * runningMultiplyer));
            }
            else
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * movementSpeed);
            }
        }
            
    }

    void PlayerMovementInput()
    {
        //set if player is moving and in what diraction
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

        //setting if the player is running
        if (isMoving && Input.GetKey(KeyCode.LeftShift) && frontColliderTrigger == 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
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
            if (isRunning)
            {
                transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", movementSpeed * runningMultiplyer);
            }
            else
            {
                transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", movementSpeed);
            }
            
        }
        else
        {
            transform.GetChild(0).GetComponent<Animator>().SetFloat("speed", 0);
        }           
    }
    private void OnTriggerEnter(Collider other)
    {
        frontColliderTrigger++;
    }

    private void OnTriggerExit(Collider other)
    {
        frontColliderTrigger--;
    }

}