using UnityEngine;
using System.Collections;

public class TorchBehaviour : MonoBehaviour
{

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
        if(other.gameObject.CompareTag("WallHidden"))
        {
            other.GetComponent<WallHiddenBehaviour>().ChangeMaterial();
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("WallHidden"))
        {
            other.GetComponent<WallHiddenBehaviour>().ChangeMaterial();
        }
    }
}
