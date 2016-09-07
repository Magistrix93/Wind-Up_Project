using UnityEngine;
using System.Collections;

public class WallHiddenBehaviour : MonoBehaviour
{

    public Material[] materials;

    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMaterial()
    {
        if (rend.sharedMaterial == materials[0])
            rend.sharedMaterial = materials[1];
        else
            rend.sharedMaterial = materials[0];
    }

}
