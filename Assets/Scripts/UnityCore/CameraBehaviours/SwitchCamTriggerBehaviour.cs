using UnityEngine;
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
                
            }
    }
}
