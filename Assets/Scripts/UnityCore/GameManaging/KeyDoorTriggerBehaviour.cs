using UnityEngine;
using System;
using System.Collections;

public class KeyDoorTriggerBehaviour : MonoBehaviour
{
    [NonSerialized]
    public bool chiave;

    // Use this for initialization
    void Start()
    {
        chiave = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chiave=true;
            Destroy(gameObject);
        }
    }
}
