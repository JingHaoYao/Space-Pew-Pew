using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningPortal : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 1.333f/2);
	}
	
	void Update () {
		
	}
}
