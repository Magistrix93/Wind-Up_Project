using UnityEngine;
using System.Collections;

public class CubeTileBehaviour : MonoBehaviour
{
    private Material[] materials;

    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        materials = rend.materials;
        materials[0].mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.y);
        materials[1].mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z);
        materials[2].mainTextureScale = new Vector2(transform.localScale.z, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
