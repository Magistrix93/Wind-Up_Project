using UnityEngine;
using System.Collections;
using System;

public class PlatMoveBehaviour : MonoBehaviour
{

    public Transform[] Plat;
    public float speed;
    public float wait;

    private Vector3 actualPosition;
    private int i;
    private bool start;
    private int size;
    private bool coroutineChecker;
    private bool inWaiting;

    private BoxCollider coll;


    // Use this for initialization
    void Start()
    {
        i = 0;
        start = true;
        inWaiting = true;
        coroutineChecker = false;
        size = Plat.Length;
        actualPosition = transform.position;
        StartCoroutine(Attesa());
        coll = transform.Find("piatt_mobile").GetComponent<BoxCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!coll.isTrigger)
            if (!inWaiting)
            {
                if (start)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Plat[i].position, speed * Time.deltaTime);

                    if (transform.position == Plat[i].position)
                        i++;

                    if (i == size)
                    {
                        inWaiting = true;

                        start = false;
                        i -= 2;
                    }
                }

                if (!start)
                    if (i < 0)
                    {

                        transform.position = Vector3.MoveTowards(transform.position, actualPosition, speed * Time.deltaTime);

                        if (transform.position == actualPosition)
                        {
                            inWaiting = true;
                            i = 0;
                            start = true;
                        }
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, Plat[i].position, speed * Time.deltaTime);

                        if (transform.position == Plat[i].position)
                            i--;
                    }
                
            }

            else if (!coroutineChecker)
                 StartCoroutine(Attesa());
            
    }

    private IEnumerator Attesa()
    {
        coroutineChecker = true;
        yield return new WaitForSeconds(wait);
        inWaiting = false;
        coroutineChecker = false;
    }
}
