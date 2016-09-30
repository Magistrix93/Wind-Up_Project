using UnityEngine;
using System.Collections;

public class VisorBehaviour : MonoBehaviour
{
    private GameObject spotlight;
    public GameObject player;
    private Material mat;
    private GameObject conoMesh;
    // Use this for initialization
    void Start()
    {
        spotlight = transform.Find("Spotlight").gameObject;
        GetComponent<MeshCollider>().enabled = false;
        conoMesh = transform.Find("Mesh Renderer").gameObject;
        conoMesh.GetComponent<MeshRenderer>().enabled = false;
        spotlight.SetActive(false);
        mat = player.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }   

    public void Active()
    {
        GetComponent<MeshCollider>().enabled = true;
        conoMesh.GetComponent<MeshRenderer>().enabled = true;
        spotlight.SetActive(true);
        mat.SetFloat("_MKGlowPower", 1f);
        mat.SetFloat("_MKGlowTexStrength", 1f);
        mat.SetFloat("_Emission", 1f);
    }

}
