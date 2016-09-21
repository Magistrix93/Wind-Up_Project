using UnityEngine;
using System.Collections;

public class PickUpVisorBehaviour : MonoBehaviour
{

    private GameObject visor;

    // Use this for initialization
    void Start()
    {
        visor = GameObject.FindGameObjectWithTag("Visor");
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
            visor.GetComponent<VisorBehaviour>().Active();
            Destroy(gameObject);
        }
    }
}
