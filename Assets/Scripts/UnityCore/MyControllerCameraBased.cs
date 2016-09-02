using UnityEngine;
using System.Collections;
using System;


public class MyControllerCameraBased : MonoBehaviour
{
    private float Speed;
    public bool CanJump;
    private CharacterController MyController;
    private float JumpSpeed;
    public Vector3 MoveDirection;
    private float RunMultiplier;
    private float RunSpeed;

    public bool Jumping;
    public bool Grounded;
    public bool Falling;
    private bool CheckRoutine;

    private Vector3 CameraDirectionX;
    private Vector3 CameraDirectionY;

    // Use this for initialization
    void Start()
    {
        Speed = GetComponent<CharacterBehaviour>().character.Speed;
        MyController = GetComponent<CharacterController>();
        JumpSpeed = GetComponent<CharacterBehaviour>().character.JumpSpeed;
        RunMultiplier = GetComponent<CharacterBehaviour>().character.RunMultiplier;
        RunSpeed = 1f;
        CanJump = false;
        Jumping = false;
        Grounded = false;
        Falling = false;
        MoveDirection = Vector3.zero;

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (MyController.isGrounded)
        {
            Grounded = true;
            Falling = false;
        }
        else
            Grounded = false;



        if (Grounded)
        {
            if (!Input.GetButton("Jump"))
                CanJump = true;
            MoveDirection = Vector3.zero;
        }

        Inputcontroller();

        if (!Grounded)
            MoveDirection += Physics.gravity * Time.deltaTime;

        if (MoveDirection.y > Physics.gravity.y / 5)
            if (Input.GetButton("Jump") && CanJump)
            {
                CanJump = false;
                Jumping = true;
            }

        if (Jumping)
        {
            Jumping = false;
            MoveDirection += (JumpSpeed * Vector3.up);
        }

    }


    void LateUpdate()
    {

        if (MoveDirection != Vector3.zero)
            MyController.Move(MoveDirection * Time.deltaTime);

        if (MyController.isGrounded)
            MoveDirection = Vector3.zero;

    }

    private void Inputcontroller()
    {
        if (Input.GetButton("Run") && (MyController.isGrounded))
            RunSpeed = RunMultiplier;

        else
            RunSpeed = 1;

        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0)
                CameraDirectionX = Camera.main.transform.forward;
            else
                CameraDirectionX = -Camera.main.transform.forward;
            CameraDirectionX.y = 0;
            MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Vertical")) * Input.GetAxis("Vertical") * CameraDirectionX * RunSpeed);
        }


        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
                CameraDirectionY = Camera.main.transform.right;
            else
                CameraDirectionY = -Camera.main.transform.right;
            CameraDirectionY.y = 0;
            MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Horizontal")) * Input.GetAxis("Horizontal") * CameraDirectionY * RunSpeed);
        }
        if (!MyController.isGrounded)
        {
            MoveDirection.x /= 2;
            MoveDirection.z /= 2;
        }

    }


}