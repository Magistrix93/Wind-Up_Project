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
           if(cameraObject != actualCam.gameObject)
            {
                actualCam.enabled = !actualCam.enabled;
                actualCam.GetComponent<AudioListener>().enabled = false;                
                myCam.enabled = !myCam.enabled;
                myCam.GetComponent<AudioListener>().enabled = true;
                myCam.GetComponent<MainCameraBehaviour>().SetCamera();
                
            }
    }
}
