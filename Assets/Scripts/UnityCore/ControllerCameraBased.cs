using UnityEngine;
using System.Collections;
using System;


public class ControllerCameraBased : MonoBehaviour
{
    private float Speed;
    public bool CanJump;
    private CharacterController MyController;
    private float JumpSpeed;
    public Vector3 MoveDirection;
    private float RunMultiplier;
    private float RunSpeed;
    private float mass;

    public bool Jumping;
    public bool Grounded;

    public Vector3 CameraDirectionX;
    public Vector3 CameraDirectionY;

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
        MoveDirection = Vector3.zero;
        mass = 4f;

    }

    public void CameraDirectionSetting(GameObject activeCam)
    {
        CameraDirectionX = activeCam.transform.forward;
        CameraDirectionX.y = 0;
        CameraDirectionY = activeCam.transform.right;
        CameraDirectionY.y = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (MyController.isGrounded)
        {
            Grounded = true;
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
            MoveDirection += Physics.gravity * Time.deltaTime * mass;

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
    }

    private void Inputcontroller()
    {   
        if (MyController.isGrounded)
            if (Input.GetButton("Run"))
                RunSpeed = RunMultiplier;
            else
                RunSpeed = 1;

        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0)
                MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Vertical")) * Input.GetAxis("Vertical") * CameraDirectionX * RunSpeed);
            else
                MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Vertical")) * Input.GetAxis("Vertical") * -CameraDirectionX * RunSpeed);



        }


        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
                MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Horizontal")) * Input.GetAxis("Horizontal") * CameraDirectionY * RunSpeed);
            else
                MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Horizontal")) * Input.GetAxis("Horizontal") * -CameraDirectionY * RunSpeed);


        }
        if (!MyController.isGrounded)
        {
            MoveDirection.x /= 2.5f;
            MoveDirection.z /= 2.5f;
        }

    }


}