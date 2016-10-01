using UnityEngine;
using System;
using System.Collections;

public class PlatTurnBehaviour : MonoBehaviour
{

    private GameObject character;
    private bool controlJumping;

    private GameObject enterPoint;

    private BoxCollider coll;

    private bool stopRotation = true;
    private float direction;

    public bool teleportFaceUp;

    // Use this for initialization
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        enterPoint = transform.Find("EnterPoint").gameObject;
        coll = GetComponent<BoxCollider>();
        coll.isTrigger = false;

        if (teleportFaceUp)
        {
            direction = (-1);
            transform.Rotate(180, 0, 0);

        }
        else
        {
            direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        controlJumping = character.GetComponent<ControllerCameraBased>().platformRotate;

        if (controlJumping)
        {
            stopRotation = false;
        }

        if (!stopRotation && !teleportFaceUp && direction == 1)
        {
            transform.Rotate(direction * 180, 0, 0);
            coll.isTrigger = true;
            enterPoint.SetActive(false);
            stopRotation = true;
            teleportFaceUp = true;
            coll.isTrigger = false;
            enterPoint.SetActive(true);
            direction = direction * (-1);

        }

        if (!stopRotation && teleportFaceUp && direction == (-1))
        {
            transform.Rotate(direction * 180, 0, 0);
            coll.isTrigger = true;
            enterPoint.SetActive(false);
            stopRotation = true;
            teleportFaceUp = false;
            coll.isTrigger = false;
            direction = direction * (-1);
        }
    }
}

