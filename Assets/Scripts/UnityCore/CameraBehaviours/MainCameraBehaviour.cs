using UnityEngine;
using System.Collections;

public class MainCameraBehaviour : MonoBehaviour
{
    protected GameObject player;
    protected Vector3 direction;
    protected float step;
    protected CharacterController controller;
    protected float maxDepthDistance;
    protected float maxWidthDistance;
    protected float maxHeightDistance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        step = player.GetComponent<CharacterBehaviour>().character.Speed * 2.5f;
        controller = player.GetComponent<CharacterController>();
    }

    public void Setting(GameObject player)
    {
        maxHeightDistance = (transform.position.y - player.transform.position.y);
        maxDepthDistance = (transform.position.z - player.transform.position.z);
        maxWidthDistance = (transform.position.x - player.transform.position.x);
        player.GetComponent<ControllerCameraBased>().CameraDirectionSetting(gameObject);
    }


}
