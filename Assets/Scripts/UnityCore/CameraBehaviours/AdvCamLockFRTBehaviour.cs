using UnityEngine;
using System.Collections;

public class AdvCamLockFRTBehaviour : MainCameraBehaviour
{


    private float groundPosition;
    private Vector3 lookTarget;


    // Use this for initialization
    void Start()
    {
        GetPlayer();
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        Setting(player);        
        groundPosition = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        lookTarget = new Vector3(player.transform.position.x, groundPosition, player.transform.position.z);
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);
        transform.LookAt(lookTarget);
    }

}
