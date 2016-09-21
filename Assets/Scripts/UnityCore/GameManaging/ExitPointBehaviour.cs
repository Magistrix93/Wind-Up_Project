using UnityEngine;
using System.Collections;

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
        teleport.SetActive(true);
        teleport.transform.position = player.transform.position;
    }
}
