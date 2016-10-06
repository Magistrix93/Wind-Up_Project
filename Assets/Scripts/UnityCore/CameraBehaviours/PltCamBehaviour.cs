using UnityEngine;
using System.Collections;
using System;

public class PltCamBehaviour : MainCameraBehaviour
{
    private float groundPosition;

    private Vector3 startPosition;

    public bool resettable;

    private bool isFalling = false;

    private bool checkRoutine = false;

    private bool checkFall = false;

    // Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        startPosition = transform.position;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (controller.Grounded)
        {
            groundPosition = player.transform.position.y;
            checkRoutine = false;
            isFalling = false;
            checkFall = false;
        }

        else if(!checkRoutine)
        {
            checkFall = true;
            StartCoroutine(CheckFalling());
        }

        
            
        if (!isFalling)
            direction = new Vector3(player.transform.position.x + maxWidthDistance, groundPosition + maxHeightDistance, player.transform.position.z + maxDepthDistance);
        else
            direction = new Vector3(player.transform.position.x + maxWidthDistance, player.transform.position.y + maxHeightDistance, player.transform.position.z + maxDepthDistance);


        transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);

    }

    private IEnumerator CheckFalling()
    {
        checkRoutine = true;
        yield return new WaitForSeconds(1f);
        if ((!controller.Grounded) && (checkFall))
            isFalling = true;
    }

    public override void SetCamera()
    {
        GetPlayer();

        groundPosition = player.transform.position.y;

        if ((maxDepthDistance == 0) && (maxHeightDistance == 0) && (maxWidthDistance == 0))
            Setting(player);

        if (resettable)
            transform.position = startPosition;
        else
            SetPosition();



    }

    public void SetPosition()
    {
        transform.position = new Vector3(player.transform.position.x + maxWidthDistance, groundPosition + maxHeightDistance, player.transform.position.z + maxDepthDistance);
    }

}
