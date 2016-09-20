using UnityEngine;
using System.Collections;
using System;

public enum CharacterStates
{
    Controllable,
    Uncontrollable,
}

public class ControllerCameraBased : MonoBehaviour
{
    private float Speed;
    public bool CanJump;
    private float JumpSpeed;
    public Vector3 MoveDirection;
    private float RunMultiplier;
    private float RunSpeed;
    private float mass;

    public bool Jumping;
    public bool Grounded;
    public bool platformRotate;

    public Vector3 CameraDirectionX;
    public Vector3 CameraDirectionY;

    private Vector3 lookDirection;

    private Animator animator;

    private GameObject model;

    public int gravity;

    public float raycast;

    private RaycastHit hit;

    public CharacterStates charaStates;

    private Rigidbody rigid;


    // Use this for initialization
    void Start()
    {
        Speed = GetComponent<CharacterBehaviour>().character.Speed;
        JumpSpeed = GetComponent<CharacterBehaviour>().character.JumpSpeed;
        RunMultiplier = GetComponent<CharacterBehaviour>().character.RunMultiplier;
        rigid = GetComponent<Rigidbody>();
        RunSpeed = 1f;
        CanJump = false;
        Jumping = false;
        Grounded = false;
        MoveDirection = Vector3.zero;
        mass = 4f;
        model = transform.Find("omyno").gameObject;
        animator = model.GetComponent<Animator>();
        raycast = 1.6f;
        charaStates = CharacterStates.Controllable;
    }

    public void CameraDirectionSetting(GameObject activeCam)
    {
        CameraDirectionX = activeCam.transform.forward;
        CameraDirectionX.y = 0;
        CameraDirectionX.Normalize();

        CameraDirectionY = activeCam.transform.right;
        CameraDirectionY.y = 0;
        CameraDirectionY.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Physics.SphereCast(transform.position, 0.90f, Vector3.down, out hit, raycast))
        {
            Grounded = true;
            platformRotate = false;
            gravity = 0;
            animator.SetInteger("Gravity", gravity);
            if (hit.transform.CompareTag("Platform"))
            {
                transform.SetParent(hit.transform);
            }
            
        }

        else
        {
            Grounded = false;
            transform.parent = null;
        }


        if (Grounded)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
            MoveDirection = Vector3.zero;
            animator.SetBool("IsOnAir", false);

            if (!Input.GetButton("Jump"))
                CanJump = true;

            if (charaStates == CharacterStates.Controllable)
                if (Input.GetButton("Jump") && CanJump)
                {
                    CanJump = false;
                    Jumping = true;
                    platformRotate = true;
                }
        }

        else
            MoveDirection += Physics.gravity * Time.deltaTime * mass;

        if (Jumping)
        {
            Jumping = false;
            MoveDirection += (JumpSpeed * Vector3.up);
        }

        if (charaStates == CharacterStates.Controllable)
            Inputcontroller();

        lookDirection = new Vector3(transform.position.x + MoveDirection.x, transform.position.y, transform.position.z + MoveDirection.z);

        if (MoveDirection != Vector3.zero)
        {
            transform.position += MoveDirection * Time.fixedDeltaTime;
        }

        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsSprinting", false);
        }

        if (gravity == 0)
        {
            gravity = (int)MoveDirection.y;
            animator.SetInteger("Gravity", gravity);
        }

        transform.LookAt(lookDirection);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

    }


    private void Inputcontroller()
    {
        if (Grounded)
            if (Input.GetButton("Run"))
            {
                RunSpeed = RunMultiplier;
                if (animator.GetBool("IsRunning"))
                    animator.SetBool("IsSprinting", true);
            }

            else
            {
                RunSpeed = 1;
                animator.SetBool("IsSprinting", false);
            }


        if ((Input.GetAxis("Vertical") != 0) || (Input.GetAxis("Horizontal") != 0))
        {
            if (Input.GetAxis("Vertical") != 0)
                MoveDirection += (Speed * Input.GetAxis("Vertical") * CameraDirectionX * RunSpeed);

            if (Input.GetAxis("Horizontal") != 0)
                MoveDirection += (Speed * Input.GetAxis("Horizontal") * CameraDirectionY * RunSpeed);

            if (Grounded)
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