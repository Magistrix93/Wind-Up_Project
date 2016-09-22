using UnityEngine;
using System.Collections;

public class PlatTurnAnimationBehaviour : MonoBehaviour
{
    public GameObject character;
    public bool controlJumping;

    private GameObject enterPoint;

    private BoxCollider coll;

    public bool stopRotation = true;
    public float direction;

    public float speed;

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
            transform.Rotate(Time.deltaTime * speed * direction * 180, 0, 0);
            coll.isTrigger = true;
            enterPoint.SetActive(false);

            if (transform.eulerAngles.x > 180)
            {
                stopRotation = true;
                teleportFaceUp = true;
                coll.isTrigger = false;
                enterPoint.SetActive(true);
                direction = direction * (-1);
                transform.eulerAngles = new Vector3(180, 0, 0);
            }

        }

        if (!stopRotation && teleportFaceUp && direction == (-1))
        {
            transform.Rotate(Time.deltaTime * speed * direction * 180, 0, 0);
            coll.isTrigger = true;
            enterPoint.SetActive(false);

            if (transform.eulerAngles.x > 180)
            {
                stopRotation = true;
                teleportFaceUp = false;
                coll.isTrigger = false;
                direction = direction * (-1);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

        }
    }
}