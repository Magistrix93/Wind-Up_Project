using UnityEngine;
using System.Collections;

public class GameManagerBehaviour : MonoBehaviour
{

    public GameObject firstCamera;

    // Use this for initialization
    void Start()
    {
        firstCamera.GetComponent<Camera>().enabled = true;
        firstCamera.GetComponent<AudioListener>().enabled = true;
        firstCamera.GetComponent<MainCameraBehaviour>().SetCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
