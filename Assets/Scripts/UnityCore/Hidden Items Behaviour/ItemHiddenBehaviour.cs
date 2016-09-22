using UnityEngine;
using System.Collections;
using System;

public class ItemHiddenBehaviour : MonoBehaviour
{
    private Renderer rend;
    private Collider coll;

    private GameObject particles;

    private bool fading = false;
    private bool check = false;

    private Color color;
    private Color startColor;

    private float intensity = 0;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
        particles = transform.Find("Hidden_particles").gameObject;
        particles.SetActive(false);
        startColor = rend.material.GetColor("_MKGlowColor");
        startColor = new Color(0.01f, 0.01f, 0.01f);
        rend.material.SetColor("_MKGlowColor", startColor);

    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            intensity += 100 * Time.deltaTime;
            if (intensity >= 100)
                intensity = 100;
            color = startColor * intensity;
            rend.material.SetColor("_MKGlowColor", color);
            if (intensity == 100)
                fading = false;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!check)
            if ((other.CompareTag("Visor")) && (coll.isTrigger))
            {
                coll.isTrigger = false;
                rend.enabled = true;
                startColor = rend.material.GetColor("_MKGlowColor");
                fading = true;
                StartCoroutine(StartParticles());
                check = true;
            }
    }



    private IEnumerator StartParticles()
    {
        particles.SetActive(true);
        yield return new WaitForSeconds(1f);
        particles.SetActive(false);
    }
}
