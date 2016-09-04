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

    private Vector3 lookDirection;

    private Animator animator;

    private GameObject model;

    public float maxGravity;

    public float raycast;

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
        model = transform.Find("omyno").gameObject;
        animator = model.GetComponent<Animator>();
        maxGravity = 0f;
        raycast = 2.5f;

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


        if (Physics.Raycast(transform.position, Vector3.down, raycast))
            Grounded = true;

        else
            Grounded = false;




        if (Grounded)
        {
            
            MoveDirection = Vector3.zero;
            animator.SetBool("IsOnAir", false);
            animator.SetBool("IsJumping", false);
            CanJump = true;

            if (Input.GetButtonDown("Jump") && (!animator.GetCurrentAnimatorStateInfo(0).IsName("OnAir")) && CanJump)
            {
                CanJump = false;
                Jumping = true;
            }
        }
        else
            animator.SetBool("IsOnAir", false);

        

        if (!Grounded)
        {
            MoveDirection += Physics.gravity * Time.deltaTime * mass;
            animator.SetBool("IsOnAir", true);

        }

        //if (!Physics.Raycast(transform.position, Vector3.down, 0.75f))
        //    if (Input.GetButton("Jump") && )
        //    {
        //        CanJump = false;
        //        Jumping = true;

        //    }
        //    Grounded = false;

        //if (MoveDirection.y < Physics.gravity.y)

        if (Jumping)
        {
            Jumping = false;
            MoveDirection += (JumpSpeed * Vector3.up);
            animator.SetBool("IsJumping", true);
        }

        Inputcontroller();

        lookDirection = new Vector3(transform.position.x + MoveDirection.x, transform.position.y, transform.position.z + MoveDirection.z);  

        if (MoveDirection != Vector3.zero)
        {
            MyController.Move(MoveDirection * Time.deltaTime);
            transform.LookAt(lookDirection);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsSprinting", false);
        }
            

        if (maxGravity > MoveDirection.y)
            maxGravity = MoveDirection.y;
    }



    private void Inputcontroller()
    {   
        if (Grounded)
            if (Input.GetButton("Run"))
            {
                RunSpeed = RunMultiplier;
                animator.SetBool("IsSprinting", true);
            }
                
            else
            {
                RunSpeed = 1;
                animator.SetBool("IsSprinting", false);
            }
                

        if ((Input.GetAxis("Vertical") != 0) || (Input.GetAxis("Horizontal") != 0))
        {
            if (Input.GetAxis("Vertical") > 0)
                MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Vertical")) * Input.GetAxis("Vertical") * CameraDirectionX * RunSpeed);
            else
                MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Vertical")) * Input.GetAxis("Vertical") * -CameraDirectionX * RunSpeed);

            if (Input.GetAxis("Horizontal") > 0)
                MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Horizontal")) * Input.GetAxis("Horizontal") * CameraDirectionY * RunSpeed);
            else
                MoveDirection += (Speed * Mathf.Sign(Input.GetAxis("Horizontal")) * Input.GetAxis("Horizontal") * -CameraDirectionY * RunSpeed);

            if(Grounded)
                animator.SetBool("IsRunning", true);

        }

        else
        {
            if (Grounded)
                animator.SetBool("IsRunning", false);
        }


        if (!Grounded)
        {
            MoveDirection.x /= 2.5f;
            MoveDirection.z /= 2.5f;
        }

    }


}