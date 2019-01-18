using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StasisLock : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 1.5f);
	}

	void Update () {
        transform.position = GameObject.Find("PlayerSpaceShip").transform.position;

	}
}
