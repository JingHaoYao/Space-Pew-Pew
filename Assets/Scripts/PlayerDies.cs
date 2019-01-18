using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDies : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 0.667f);
	}

	void Update () {
		
	}
}
