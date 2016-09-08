using UnityEngine;
using System.Collections;

public class PltCamBehaviour : MainCameraBehaviour
{
    private float groundPosition;

    // Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();

        GetPlayer();

        groundPosition = player.transform.position.y;

        Setting(player);

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
        SetPosition();
        Setting(player);
        
    }

    public void SetPosition()
    {
        transform.position = new Vector3(player.transform.position.x + maxWidthDistance, groundPosition + maxHeightDistance, player.transform.position.z + maxDepthDistance);
    }

}
