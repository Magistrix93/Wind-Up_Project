using UnityEngine;
using System.Collections;
using System;

public class ItemPermaHiddenBehaviour : MonoBehaviour
{
    private Renderer rend;
    private Collider coll;

    private GameObject particles;

    private bool fading = false;
    private bool check = false;

    private Color color;
    private Color startColor;

    private float intensity = 0;

    private enum InOut { In, Out}

    private InOut typeFade;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
        particles = transform.Find("Hidden_particles").gameObject;
        particles.SetActive(false);
        startColor = new Color(0.01f, 0.01f, 0.01f);
        rend.material.SetColor("_EmissionColor", startColor);

    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            switch(typeFade)
            {
                case InOut.In:
                    {
                        intensity += 100 * Time.deltaTime;
                        if (intensity > 100)
                            intensity = 100;
                        color = startColor * intensity;
                        rend.material.SetColor("_EmissionColor", color);
                        if (intensity == 100)
                            fading = false;
                        break;
                    }
                case InOut.Out:
                    {
                        intensity -= 200 * Time.deltaTime;
                        if (intensity < 1)
                            intensity = 1;
                        color = startColor * intensity;
                        rend.material.SetColor("_EmissionColor", color);
                        if (intensity == 1)
                        {
                            fading = false;
                            coll.isTrigger = true;
                            rend.enabled = false;
                        }                            
                        break;
                    }
            }
            

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!check)
            if (other.CompareTag("Visor"))
            {
                particles.SetActive(false);
                StopAllCoroutines();
                coll.isTrigger = false;
                rend.enabled = true;
                fading = true;
                typeFade = InOut.In;
                intensity = 0;
                StartCoroutine(StartParticles());
                check = true;
            }
    }

    void OnTriggerExit(Collider other)
    {
        if (check)
            if (other.CompareTag("Visor"))
            {
                particles.SetActive(false);
                StopAllCoroutines();
                fading = true;
                typeFade = InOut.Out;
                intensity = 100;
                StartCoroutine(StartParticles());
                check = false;
            }
    }



    private IEnumerator StartParticles()
    {
        if(!particles.activeSelf)
            particles.SetActive(true);
        yield return new WaitForSeconds(1f);
        if(particles.activeSelf)
            particles.SetActive(false);
    }
}
