using UnityEngine;
using MKGlowSystem;
using System.Collections;

public class CubeTileBehaviour : MonoBehaviour
{
    private Material[] materials;

    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        SetTiling();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTiling()
    {
        materials = rend.materials;
        materials[0].SetTextureScale("_MKGlowTex", new Vector2(transform.localScale.x, transform.localScale.y));
        materials[1].SetTextureScale("_MKGlowTex", new Vector2(transform.localScale.x, transform.localScale.z));
        materials[2].SetTextureScale("_MKGlowTex", new Vector2(transform.localScale.z, transform.localScale.y));
    }
}
