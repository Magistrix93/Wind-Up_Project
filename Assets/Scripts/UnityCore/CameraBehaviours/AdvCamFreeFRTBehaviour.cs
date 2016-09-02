using UnityEngine;
using System.Collections;

public class AdvCamFreeFRTBehaviour : MainCameraBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetPlayer();

        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        Setting(player);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(player.transform.position.x, player.transform.position.y + maxHeightDistance, transform.position.z);
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, step * Time.deltaTime);
        transform.LookAt(player.transform.position);
    }

}