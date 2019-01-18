using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapalmShot : MonoBehaviour {
    float angle = NapalmLauncherScript.angle;
    public GameObject napalmCollision;

	void Start () {
		
	}

	void Update () {
        transform.position += new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * 12 * Time.deltaTime;
        if(transform.position.y <= -4.7f)
        {
            Instantiate(napalmCollision, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
	}
}
