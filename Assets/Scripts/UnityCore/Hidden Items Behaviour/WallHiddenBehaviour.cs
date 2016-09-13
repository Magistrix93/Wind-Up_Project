using UnityEngine;
using System.Collections;

public class WallHiddenBehaviour : MonoBehaviour
{



    public Material trasparentMat;

    private Collider coll;

    private Color color;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Torch"))
        {
            GetComponent<Renderer>().sharedMaterial = trasparentMat;

            coll.isTrigger = true;
        }
    }

}
