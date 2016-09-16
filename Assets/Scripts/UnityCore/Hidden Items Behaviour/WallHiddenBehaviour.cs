using UnityEngine;
using System.Collections;

public class WallHiddenBehaviour : MonoBehaviour
{

    private Renderer rend;

    private Material[] traspMaterials;

    private Collider coll;

    private bool triggered = false;

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

    }

    void OnTriggerEnter(Collider other)
    {
        if(!triggered)
            if(other.CompareTag("Torch"))
            {
                rend.materials = traspMaterials;

                GetComponent<CubeTileBehaviour>().SetTiling();
                coll.isTrigger = true;
                triggered = true;
            }
    }

}
