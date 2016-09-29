using UnityEngine;
using System.Collections;

public class muro_porta : MonoBehaviour {

    public GameObject trigger;

    private Transform cubo1;
    private Transform cubo2;
    private Transform cubo3;
    private Transform cubo4;
    private Transform cubo5;
    private Transform cubo6;
    private Transform cubo7;
    private Transform cubo8;
    private Transform cubo9;




	// Use this for initialization
	void Start () {

        cubo1 = transform.Find("cubo_1");
        cubo2 = transform.Find("cubo_2");
        cubo3 = transform.Find("cubo_3");
        cubo4 = transform.Find("cubo_4");
        cubo5 = transform.Find("cubo_5");
        cubo6 = transform.Find("cubo_6");
        cubo7 = transform.Find("cubo_7");
        cubo8 = transform.Find("cubo_8");
        cubo9 = transform.Find("cubo_9");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
