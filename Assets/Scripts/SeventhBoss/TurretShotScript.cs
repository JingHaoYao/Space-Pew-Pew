using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShotScript : MonoBehaviour {
    public float downSpeed = 5;
    public float sideSpeed = 8;
    public bool goingRight = false;
    public GameObject explosion;

    void Start () {
		
	}

	void Update () {
        if(goingRight == true)
        {
            transform.position += Vector3.right * sideSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * sideSpeed * Time.deltaTime;
        }

        transform.position += Vector3.down * downSpeed * Time.deltaTime;

		if(transform.position.x < -9 || transform.position.x > 9 || transform.position.x < -7)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
