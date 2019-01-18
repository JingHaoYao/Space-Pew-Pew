using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endExplosion : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 1.333f/2f);
	}

	void Update () {
		
	}
}
