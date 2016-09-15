using UnityEngine;
using System.Collections;

public class PickUpTorchBehaviour : MonoBehaviour
{

    private GameObject torch;

    // Use this for initialization
    void Start()
    {
        torch = GameObject.FindGameObjectWithTag("Torch");
        GetComponent<BoxCollider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            torch.GetComponent<TorchBehaviour>().Active();
            Destroy(gameObject);
        }
    }
}
