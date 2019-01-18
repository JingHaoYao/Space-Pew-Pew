using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDead : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 0.833f/2f);
	}
	
	void Update () {
		
	}
}
