using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorTriggerBehaviour : MonoBehaviour
{
    public GameObject key;
    public KeyDoorTriggerBehaviour porta;

    // Use this for initialization
    void Start()
    {
        porta = key.GetComponent<KeyDoorTriggerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (porta.chiave)
                SceneManager.LoadScene("scena 3");

        }
    }
}
