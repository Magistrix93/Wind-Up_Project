using UnityEngine;
using System.Collections;

public class SwitchActivatorBehaviour : MonoBehaviour
{
    private GameObject[] findCubeA;
    private GameObject[] findCubeB;
    private int lenghtA;
    private int lenghtB;

    // Use this for initialization
    void Start()
    {
        findCubeA = GameObject.FindGameObjectsWithTag("cuboA");
        findCubeB = GameObject.FindGameObjectsWithTag("cuboB");
        lenghtA = findCubeA.Length;
        lenghtB = findCubeB.Length;

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < lenghtA; i++)
            {
                findCubeA[i].GetComponent<CuboSwitchBehaviour>().MovingCubes();
            }
            for (int j = 0; j < lenghtB; j++)
            {
                findCubeB[j].GetComponent<CuboSwitchBehaviour>().MovingCubes();
            }


        }
    }
}
