using UnityEngine;
using System.Collections;
using System;

public class AdvCamLockSIDEBehaviour : MainCameraBehaviour
{


    private float groundPosition;
    private Vector3 lookTarget;


    // Use this for initialization
    void Start()
    {
        GetPlayer();

        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);

        groundPosition = player.transform.position.y;

        Setting(player);

        thisCamera = GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
        if(thisCamera.enabled)
        {
            direction = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
            lookTarget = new Vector3(player.transform.position.x, groundPosition, player.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);
            transform.LookAt(lookTarget);
        }
        
    }

    public override void SetCamera()
    {
        GetPlayer();

        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);        

        groundPosition = player.transform.position.y;
    }

}
