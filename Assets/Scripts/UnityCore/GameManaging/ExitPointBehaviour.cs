using UnityEngine;
using System.Collections;
using System;

public class ExitPointBehaviour : MonoBehaviour
{

    private GameObject teleport;
    private GameObject player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        teleport = transform.Find("TeleportExit").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Arrived()
    {
        teleport.transform.position = player.transform.position;
        teleport.SetActive(true);
        StartCoroutine(Teleporting());
        Camera.main.gameObject.GetComponent<MainCameraBehaviour>().SetCamera();
    }

    private IEnumerator Teleporting()
    {
        yield return new WaitForSeconds(0.3f);
        teleport.SetActive(false);
    }
}
