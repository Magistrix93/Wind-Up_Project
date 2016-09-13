using UnityEngine;
using System.Collections;

public class ExitPointBehaviour : MonoBehaviour
{

    private GameObject teleport;

    // Use this for initialization
    void Start()
    {
        teleport = transform.Find("TeleportExit").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Arrived()
    {
        teleport.SetActive(true);
    }
}
