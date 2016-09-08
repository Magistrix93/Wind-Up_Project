using UnityEngine;
using System.Collections;

public class WallHiddenBehaviour : MonoBehaviour
{

    private Material material;

    private Collider coll;

    private Color color;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider>();
        material = GetComponent<Renderer>().material;
        color = material.color;

        color.a -= 0.4f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Torch"))
        {
            material.color = color;
            coll.isTrigger = true;
        }
    }

}
