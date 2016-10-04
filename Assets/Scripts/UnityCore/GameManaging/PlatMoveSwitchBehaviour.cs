using UnityEngine;
using System.Collections;

public class PlatMoveSwitchBehaviour : MonoBehaviour
{
    public GameObject[] transpPlats;
    private Vector3 startPosition;
    private bool rising = true;
    private Vector3 upPosition;
    private Vector3 downPosition;
    private int nPlats;
    public bool onOff;

    private Renderer rend;

    private float glowPower;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        upPosition = new Vector3(startPosition.x, startPosition.y + 0.3f, startPosition.z);
        downPosition = new Vector3(startPosition.x, startPosition.y - 0.3f, startPosition.z);
        nPlats = transpPlats.Length;
        rend = GetComponent<Renderer>();
        if (onOff)
            for (int i = 0; i < nPlats; i++)
                transpPlats[i].SetActive(true);
        else
            for (int i = 0; i < nPlats; i++)
                transpPlats[i].SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (rising)
        {
            transform.position = Vector3.MoveTowards(transform.position, upPosition, 0.3f * Time.deltaTime);
            if (transform.position == upPosition)
                rising = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, downPosition, 0.3f * Time.deltaTime);
            if (transform.position == downPosition)
                rising = true;
        }

        if (onOff)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 4, transform.eulerAngles.z);
            glowPower = rend.material.GetFloat("_MKGlowPower");
            glowPower = 3;
            rend.material.SetFloat("_MKGlowPower", glowPower);
        }
        else
        {
            glowPower = rend.material.GetFloat("_MKGlowPower");
            glowPower = 0;
            rend.material.SetFloat("_MKGlowPower", glowPower);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Visor"))
        {
            if (!onOff)
            {
                for (int i = 0; i < nPlats; i++)
                {
                    transpPlats[i].SetActive(true);
                }
                onOff = true;

            }

            else
            {
                for (int i = 0; i < nPlats; i++)
                {
                    transpPlats[i].SetActive(false);
                }
                onOff = false;

            }
        }
    }

}
