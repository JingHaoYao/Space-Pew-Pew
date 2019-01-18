using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontPlateFollow : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        transform.position = GameObject.Find("FourthBossFireLaser").transform.position + new Vector3(0, -4.8f, 0);
	}
}
