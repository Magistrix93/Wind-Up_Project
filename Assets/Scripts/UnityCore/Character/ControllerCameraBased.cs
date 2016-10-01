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
    private bool CanJump;
    private float JumpSpeed;
    private Vector3 MoveDirection;
    private float RunMultiplier;
    private float RunSpeed;
    private float mass;

    private bool Jumping;

    [NonSerialized]
    public bool Grounded;

    [NonSerialized]
    public bool platformRotate = false;

    private Vector3 CameraDirectionX;
    private Vector3 CameraDirectionY;

    private Vector3 lookDirection;

    private Animator animator;

    private GameObject model;

    private float gravity;

    private float raycast;

    private RaycastHit hit;

    [NonSerialized]
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
        model = transform.Find("omino_unity").gameObject;
        animator = model.GetComponent<Animator>();
        raycast = 1.45f;
        charaStates = CharacterStates.Controllable;
    }

    public void CameraDirectionSetting(Vector3 camForward, Vector3 camRight)
    {
        CameraDirectionX = camForward;
        CameraDirectionY = camRight;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Physics.SphereCast(transform.position, 0.80f, Vector3.down, out hit, raycast))
        {
            Grounded = true;            
            if (hit.transform.CompareTag("Platform"))
            {
                transform.SetParent(hit.transform.parent);
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
            animator.speed = 1;
            gravity = 0;

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
        {
            MoveDirection += Physics.gravity * Time.deltaTime * mass;
            gravity = MoveDirection.y / mass;
        }

        if (Jumping)
        {
            Jumping = false;
            MoveDirection += (JumpSpeed * Vector3.up);
        }

        if (charaStates == CharacterStates.Controllable)
            Inputcontroller();

        if (MoveDirection != Vector3.zero)
        {
            transform.position += MoveDirection * Time.fixedDeltaTime;
        }

        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsSprinting", false);
        }

        if(Mathf.Abs(gravity) > 0.3f )
            animator.SetBool("IsMidair", true);
        else if (Grounded)
            animator.SetBool("IsMidair", false);

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

            animator.speed = Mathf.Abs( Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"));

            lookDirection = new Vector3(transform.position.x + MoveDirection.x, transform.position.y, transform.position.z + MoveDirection.z);

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
    void LateUpdate()
    {
        platformRotate = false;
    }

}