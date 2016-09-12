using UnityEngine;
using System.Collections;

public class PltCamBehaviour : MainCameraBehaviour
{
    private float groundPosition;

    private Vector3 startPosition;

    public bool resettable;

    // Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        startPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (thisCamera.enabled)
        {
            if (controller.Grounded)
                groundPosition = player.transform.position.y;

            direction = new Vector3(player.transform.position.x + maxWidthDistance, groundPosition + maxHeightDistance, player.transform.position.z + maxDepthDistance);

            transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);
        }
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
