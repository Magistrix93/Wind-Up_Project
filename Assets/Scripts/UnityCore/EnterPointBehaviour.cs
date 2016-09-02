﻿using UnityEngine;
using System.Collections;

public class EnterPointBehaviour : MonoBehaviour
{

    public GameObject newSection;
    public GameObject newExitPoint;
    private GameObject player;
    private GameObject thisSection;

    private GameObject newCam;

    // Use this for initialization
    void Start()
    {
        thisSection = transform.root.gameObject;
        newCam = newSection.transform.Find("Main Camera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            newSection.SetActive(true);
            player.transform.position = newExitPoint.transform.position;
            thisSection.SetActive(false);
            other.gameObject.GetComponent<ControllerCameraBased>().CameraDirectionSetting(newCam);
        }

    }

}