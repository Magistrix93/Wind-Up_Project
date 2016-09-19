using UnityEngine;
using System.Collections;

public class VisorBehaviour : MonoBehaviour
{
    private GameObject spotlight;
    // Use this for initialization
    void Start()
    {
        spotlight = transform.Find("Spotlight").gameObject;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        spotlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }   

    public void Active()
    {
        GetComponent<MeshCollider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
        spotlight.SetActive(true);
    }

}
