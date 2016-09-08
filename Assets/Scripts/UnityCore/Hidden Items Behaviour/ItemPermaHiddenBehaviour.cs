using UnityEngine;
using System.Collections;

public class ItemPermaHiddenBehaviour : MonoBehaviour
{
    private Renderer rend;
    private Collider coll;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        coll = GetComponent<Collider>();
        coll.isTrigger = true;


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torch"))
        {
            coll.isTrigger = false;
            rend.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Torch"))
        {
            coll.isTrigger = true;
            rend.enabled = false;
        }
    }
}
