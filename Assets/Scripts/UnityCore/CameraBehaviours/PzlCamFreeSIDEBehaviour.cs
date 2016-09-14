﻿using UnityEngine;
using System.Collections;
using System;

public class PzlCamFreeSIDEBehaviour : MainCameraBehaviour
{
    public bool LookOnCharacter = true;

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
            direction = new Vector3(transform.position.x, player.transform.position.y + maxHeightDistance, player.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);

            if (LookOnCharacter)
                transform.LookAt(player.transform.position);
        }
        
    }

    public override void SetCamera()
    {
        GetPlayer();

        Setting(player);

        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);

    }


}