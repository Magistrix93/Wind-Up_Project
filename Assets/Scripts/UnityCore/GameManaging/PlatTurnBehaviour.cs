using UnityEngine;
using System.Collections;

public class PlatTurnBehaviour : MonoBehaviour
{
    private GameObject character;
    private bool groundControl;
    private bool controlJumping;

    private GameObject enterPoint;

    private BoxCollider coll;

    private bool stopRotation = true;
    private float direction;

    public float speed;

    //public float sizeX;
    //public float sizeZ;

    //private float sizeY;

    // Use this for initialization
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        enterPoint = transform.Find("EnterPoint").gameObject;
        coll = GetComponent<BoxCollider>();
        coll.isTrigger = false;
        //sizeY = 2.5f;
        //transform.localScale = new Vector3(5 * sizeX, sizeY, 5 * sizeZ);

        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        controlJumping = character.GetComponent<ControllerCameraBased>().platformRotate;

        if (controlJumping)
        {
            stopRotation = false;
        }

        if (!stopRotation && direction == 1 )
        {
            transform.Rotate(Time.deltaTime * speed * direction * 180, 0, 0);
            coll.isTrigger = true;
            enterPoint.SetActive(false);

            if (transform.eulerAngles.x > 180)
            {
                stopRotation = true;
                coll.isTrigger = false;
                enterPoint.SetActive(true);
                direction = direction * (-1);
                transform.eulerAngles = new Vector3(180, 0, 0);
            }

        }

        if (!stopRotation && direction == (-1))
        {
            transform.Rotate(Time.deltaTime * speed * direction * 180, 0, 0);
            coll.isTrigger = true;
            enterPoint.SetActive(false);

            if (transform.eulerAngles.x > 180)
            {
                stopRotation = true;
                coll.isTrigger = false;
                direction = direction * (-1);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

        }
    }
}

