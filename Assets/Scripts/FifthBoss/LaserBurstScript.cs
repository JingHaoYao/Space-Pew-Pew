using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBurstScript : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 0.917f / 2f);
	}
	
	void Update () {
		
	}
}
