using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sakamoto : MonoBehaviour {
	void Start () {
		
	}

	void Update () {
        transform.position += Vector3.down * Time.deltaTime * 3;
        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
	}
}
