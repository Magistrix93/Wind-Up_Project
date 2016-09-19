using UnityEngine;
using System.Collections;

public class WallHiddenBehaviour : MonoBehaviour
{

    private Renderer rend;

    private Material[] traspMaterials;

    private Collider coll;

    private bool triggered = false;

    private bool fading = false;

    private Color color;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
        traspMaterials = new Material[3];
        traspMaterials[0] = Resources.Load<Material>("FacceWidthDepthTransp");
        traspMaterials[1] = Resources.Load<Material>("FacceDepthHeightTrasp");
        traspMaterials[2] = Resources.Load<Material>("FacceWidthHeghtTransp");
    }

    // Update is called once per frame
    void Update()
    {
        if(fading)
        {
            color = rend.materials[0].GetColor("_Color");
            color.a -= 0.5f * Time.deltaTime;
            if (color.a <= 0.35f)
            {
                color.a = 0.35f;
                fading = false;
            }                
            rend.materials[0].SetColor("_Color", color);
            rend.materials[1].SetColor("_Color", color);
            rend.materials[2].SetColor("_Color", color);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!triggered)
            if(other.CompareTag("Visor"))
            {
                rend.materials = traspMaterials;

                GetComponent<CubeTileBehaviour>().SetTiling();
                fading = true;
                coll.isTrigger = true;
                triggered = true;
            }
    }

}
