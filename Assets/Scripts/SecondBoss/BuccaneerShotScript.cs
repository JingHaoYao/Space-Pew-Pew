using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuccaneerShotScript : MonoBehaviour {
    float speedBullet = 30;
    float step;
    float angleShot;

	void Start(){
        step = speedBullet * Time.deltaTime;
        angleShot = BuccaneerShooterScript.angle * Mathf.Deg2Rad;
	}
	
	void Update(){
        transform.position += new Vector3(Mathf.Cos(angleShot), Mathf.Sin(angleShot), 0) * step;

        if(transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "SecondBoss" && col.gameObject.name != "PirateCannon1" && 
            col.gameObject.name != "PirateCannon2" && col.gameObject.name != "PirateCannon3")
        {
            Destroy(this.gameObject);
        }
    }
}
