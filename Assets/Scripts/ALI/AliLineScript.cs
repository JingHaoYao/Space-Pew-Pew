using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliLineScript : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(this.gameObject);
        }
	}
}
