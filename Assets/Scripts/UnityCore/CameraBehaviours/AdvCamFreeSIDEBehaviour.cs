using UnityEngine;
using System.Collections;
using System;

public class AdvCamFreeSIDEBehaviour : MainCameraBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetPlayer();

        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);

        Setting(player);

        thisCamera = GetComponent<Camera>();
    }

   
    // Update is called once per frame
    void Update()
    {
        if(thisCamera.enabled)
        {
            direction = new Vector3(transform.position.x, player.transform.position.y + maxHeightDistance, player.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);

            transform.LookAt(player.transform.position);
        }
        
    }

    public override void SetCamera()
    {
        GetPlayer();

        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);

    }


}
