using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlatformScript : MonoBehaviour {
    public float speed = 5;

	void Start () {
		
	}

	void Update () {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }
}
