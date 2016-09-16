using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorTriggerBehaviour : MonoBehaviour
{
    public GameObject key;
    private KeyDoorTriggerBehaviour door;
    private bool accessON;

    // Use this for initialization
    void Start()
    {
        accessON = false;
        door = key.GetComponent<KeyDoorTriggerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door.chiave)
            accessON = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (accessON)
                SceneManager.LoadScene("scena 3");

        }
    }
}
