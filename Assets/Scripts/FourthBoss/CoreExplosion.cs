using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreExplosion : MonoBehaviour {
    Vector3 origPosition1 = new Vector3(0, 0, 0);
    Vector3 origPosition2 = new Vector3(0, 0, 0);

    void Start () {
        Destroy(this.gameObject, 1.333f / 2f);
        origPosition1 = transform.position;
        origPosition2 = GameObject.Find("FourthBoss").transform.position;
    }

	void Update () {
        Vector3 change = GameObject.Find("FourthBoss").transform.position - origPosition2;
        transform.position = origPosition1 + change;
    }
}
