using UnityEngine;
using Prime31.TransitionKit;
using System.Collections;

public class SwitchCamTriggerBehaviour : MonoBehaviour
{
    public GameObject cameraObject;

    private GameObject actualCam;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        actualCam = Camera.main.gameObject;
        if(other.gameObject.CompareTag("Player"))
           if(!cameraObject.activeSelf)
            {
                actualCam.SetActive(false);

                cameraObject.SetActive(true);

                cameraObject.GetComponent<MainCameraBehaviour>().SetCamera();

                var fishEye = new FishEyeTransition()
                {
                    duration = 0.3f,
                    size = 0.1f,
                    zoom = 100.0f,
                    colorSeparation = 0.1f
                };
                TransitionKit.instance.transitionWithDelegate(fishEye);

            }
    }
}
