using UnityEngine;
using System.Collections;

public class PltCamBehaviour : MainCameraBehaviour
{
    private float groundPosition;
    // Use this for initialization
    void Start()
    {
        GetPlayer();
        Setting(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void LateUpdate()
    {
        if (controller.isGrounded)
            groundPosition = player.transform.position.y;
            
        direction = new Vector3(player.transform.position.x + maxWidthDistance, groundPosition + maxHeightDistance, player.transform.position.z + maxDepthDistance);
        transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);
    }


}
