using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateExplosion : MonoBehaviour {
    Vector3 origPosition1 = new Vector3(0, 0, 0);
    Vector3 origPosition2 = new Vector3(0, 0, 0);

	void Start () {
        origPosition1 = transform.position;
        origPosition2 = GameObject.Find("FourthBoss").transform.position;
        Destroy(this.gameObject, 1.083f);
	}
	
	void Update () {
        Vector3 change = GameObject.Find("FourthBoss").transform.position - origPosition2;
        transform.position = origPosition1 + change;
	}
}
