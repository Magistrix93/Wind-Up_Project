using UnityEngine;
using System;
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

    public GameObject[] all;

    private bool checkFor = true;

    public int nSwitches;
    // Use this for initialization
    void Start()
    {
        all = GameObject.FindGameObjectsWithTag("PlatMoveSwitch");
        nSwitches = all.Length;
        startPosition = transform.position;
        upPosition = new Vector3(startPosition.x, startPosition.y + 0.3f, startPosition.z);
        downPosition = new Vector3(startPosition.x, startPosition.y - 0.3f, startPosition.z);
        nPlats = transpPlats.Length;
        rend = GetComponent<Renderer>();
        ActivePlats();
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
            if (!checkFor)
                ActivePlats();



        }
        else
        {
            glowPower = rend.material.GetFloat("_MKGlowPower");
            glowPower = 0;
            rend.material.SetFloat("_MKGlowPower", glowPower);
            if (!checkFor)
                ActivePlats();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Visor"))
        {
            if (!onOff)
            {
                onOff = true;
                checkFor = false;
                for (int i = 0; i < nSwitches; i++)
                    if (all[i] != gameObject)
                    {
                        all[i].GetComponent<PlatMoveSwitchBehaviour>().onOff = false;
                        all[i].GetComponent<PlatMoveSwitchBehaviour>().ActivePlats();
                    }
                       
            }

            else
            {

                checkFor = false;
                onOff = false;
            }
        }
    }


    private void ActivePlats()
    {
        checkFor = true;
        if (onOff)
            for (int i = 0; i < nPlats; i++)
            {
                transpPlats[i].transform.Find("piatt_mobile").GetComponent<Renderer>().enabled = true;
                transpPlats[i].transform.Find("piatt_mobile").GetComponent<BoxCollider>().isTrigger = false;
            }
                
        else
            for (int i = 0; i < nPlats; i++)
            {
                transpPlats[i].transform.Find("piatt_mobile").GetComponent<Renderer>().enabled = false;
                transpPlats[i].transform.Find("piatt_mobile").GetComponent<BoxCollider>().isTrigger = true;
            }


    }
}
