using UnityEngine;
using System.Collections;

public class trig_muro_porta : MonoBehaviour {

    public GameObject character;
    public bool doorActive;

    

	// Use this for initialization
	void Start () {

        character = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {

        }
    }

}
