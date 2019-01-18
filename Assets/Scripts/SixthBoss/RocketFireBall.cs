using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFireBall : MonoBehaviour {
    public int dirAngle;
    public float speed = 5;

	void Start () {
		
	}

	void Update () {
        transform.position += new Vector3(Mathf.Cos(dirAngle * Mathf.Deg2Rad), Mathf.Sin(dirAngle * Mathf.Deg2Rad), 0) * Time.deltaTime * speed;
        if(transform.position.y < -9)
        {
            Destroy(this.gameObject);
        }
	}
}
