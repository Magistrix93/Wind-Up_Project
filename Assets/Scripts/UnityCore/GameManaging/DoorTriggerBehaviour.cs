using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorTriggerBehaviour : MonoBehaviour
{
    private GameObject key;
    private KeyDoorTriggerBehaviour door;
    private bool accessON;
    private Texture emissSbloccata;
    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        key = GameObject.FindGameObjectWithTag("Key");
        accessON = false;
        door = key.GetComponent<KeyDoorTriggerBehaviour>();
        emissSbloccata = Resources.Load<Texture>("emiss_sbloccata");
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door.chiave)
            accessON = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (accessON))
            rend.material.SetTexture("_MKGlowTex", emissSbloccata);
    }

}
