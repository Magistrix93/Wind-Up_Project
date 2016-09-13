using UnityEngine;
using System.Collections;
using System;

public class EnterPointBehaviour : MonoBehaviour
{


    public GameObject newExitPoint;
    private GameObject player;

    private GameObject teleport;

    private bool checkRoutine = false;


    // Use this for initialization
    void Start()
    {
        teleport = transform.Find("TeleportEnter").gameObject;
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

            teleport.SetActive(true);
            if(!checkRoutine)
                StartCoroutine(Teleporting());
        }

    }

    private IEnumerator Teleporting()
    {
        checkRoutine = true;
        player.GetComponent<ControllerCameraBased>().charaStates = CharacterStates.Uncontrollable;
        yield return new WaitForSeconds(0.3f);
        player.transform.position = newExitPoint.transform.position;
        player.GetComponent<ControllerCameraBased>().charaStates = CharacterStates.Controllable;
        teleport.SetActive(false);
        checkRoutine = false;
    }

   

}