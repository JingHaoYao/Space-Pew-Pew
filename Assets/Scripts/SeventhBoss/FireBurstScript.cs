using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurstScript : MonoBehaviour {

    public bool goingUp = false;

	void Start () {
		
	}

	void Update () {
		if(transform.position.y > 5.3 || transform.position.y < -5.3)
        {
            Destroy(this.gameObject);
        }

        if (goingUp)
        {
            transform.position += Vector3.up * Time.deltaTime * 2;
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * 7;
        }
	}
}
