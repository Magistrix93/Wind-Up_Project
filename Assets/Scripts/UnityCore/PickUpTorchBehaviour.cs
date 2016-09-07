using UnityEngine;
using System.Collections;

public class PickUpTorchBehaviour : MonoBehaviour {

    public GameObject torch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            torch.SetActive(true);
            Destroy(gameObject);
        }
    }
}
