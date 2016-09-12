using UnityEngine;
using System.Collections;

public class SwitchCamTriggerBehaviour : MonoBehaviour
{
    public GameObject cameraObject;
    private Camera myCam;
    private Camera actualCam;

    // Use this for initialization
    void Start()
    {
        myCam = cameraObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        actualCam = Camera.current;
        if(other.gameObject.CompareTag("Player"))
           if(!cameraObject.activeSelf)
            {
                actualCam.gameObject.SetActive(false);

                cameraObject.SetActive(true);

                myCam.GetComponent<MainCameraBehaviour>().SetCamera();
                
            }
    }
}
