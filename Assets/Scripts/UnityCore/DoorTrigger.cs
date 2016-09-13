using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public GameObject key;
    public bool puoiEntrare;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puoiEntrare = key.GetComponent<KeyDoorTrigger>().chiave;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (puoiEntrare)
                SceneManager.LoadScene("scena 3");

        }
    }
}
