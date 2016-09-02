using UnityEngine;
using System.Collections;
using System;


public class MyCharacterController : MonoBehaviour
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

    private float xAxis;
    private float yAxis;

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
            Inputcontroller();
        }

        else
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
        MoveDirection.x = xAxis;
        MoveDirection.z = yAxis;

        Vector3.Normalize(MoveDirection);

        MoveDirection *= RunSpeed * Speed;

        if (MoveDirection != Vector3.zero)
            MyController.Move(MoveDirection * Time.deltaTime);

        xAxis = 0;
        yAxis = 0;
    }

    private void Inputcontroller()
    {
        if (Input.GetButton("Run"))
            RunSpeed = RunMultiplier;

        else
            RunSpeed = 1;

        if (Input.GetButton("Vertical"))
            yAxis = Input.GetAxis("Vertical");

        if (Input.GetButton("Horizontal"))
            xAxis = Input.GetAxis("Horizontal");
    }


}
