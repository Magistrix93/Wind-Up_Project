using UnityEngine;
using System.Collections;

public abstract class MainCameraBehaviour : MonoBehaviour
{
    protected GameObject player;
    protected Vector3 direction;
    protected float step;
    protected ControllerCameraBased controller;
    protected float maxDepthDistance = 0;
    protected float maxWidthDistance = 0;
    protected float maxHeightDistance = 0;
    protected Vector3 myForward;
    protected Vector3 myRight;
    protected Camera thisCamera;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        myForward = transform.forward;
        myForward.y = 0;
        myForward.Normalize();

        myRight = transform.right;
        myRight.y = 0;
        myRight.Normalize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void GetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        step = player.GetComponent<CharacterBehaviour>().character.Speed * 2.5f;
        controller = player.GetComponent<ControllerCameraBased>();
        controller.CameraDirectionSetting(myForward, myRight);
    }

    public virtual void Setting(GameObject player)
    {
        maxHeightDistance = (transform.position.y - player.transform.position.y);
        maxDepthDistance = (transform.position.z - player.transform.position.z);
        maxWidthDistance = (transform.position.x - player.transform.position.x);
    }

    public abstract void SetCamera();
   


}
