using UnityEngine;
using System.Collections;
using System;

public class AdvCamFreeFRTBehaviour : MainCameraBehaviour
{
    public bool LookOnCharacter;

    // Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
        if(thisCamera.enabled)
        {
            direction = new Vector3(player.transform.position.x, player.transform.position.y + maxHeightDistance, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);

            if (LookOnCharacter)
                transform.LookAt(player.transform.position);
        }

    }

    public override void SetCamera()
    {
        GetPlayer();

        Setting(player);

        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

}