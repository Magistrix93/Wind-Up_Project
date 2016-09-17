﻿using UnityEngine;
using System.Collections;

public class PlatTurnBehaviour : MonoBehaviour
{
    private GameObject character;
    private bool groundControl;
    private bool controlJumping;

    private bool stopRotation;
    private float direction;

    public float speed;

    public float sizeX;
    public float sizeZ;

    private float sizeY;

    // Use this for initialization
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");

        sizeY = 2.5f;
        transform.localScale = new Vector3(5 * sizeX, sizeY, 5 * sizeZ);

        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        controlJumping = character.GetComponent<ControllerCameraBased>().platformRotate;

        if (!controlJumping)
        {
            stopRotation = false;
        }

        if (controlJumping && !stopRotation && direction == 1 )
        {
            transform.Rotate(Time.deltaTime * speed * direction * 180, 0, 0);

            if (transform.eulerAngles.x > 180)
            {
                stopRotation = true;
                direction = direction * (-1);
                transform.eulerAngles = new Vector3(180, 0, 0);
            }

        }

        if (controlJumping && !stopRotation && direction == (-1))
        {
            transform.Rotate(Time.deltaTime * speed * direction * 180, 0, 0);

            if (transform.eulerAngles.x > 180)
            {
                stopRotation = true;
                direction = direction * (-1);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

        }
    }
}
