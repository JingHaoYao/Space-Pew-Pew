using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShotThirdBoss : MonoBehaviour {
    float fireAngle = RedSummonPortal.angleShot;
    public GameObject lightningClash, thirdBossExplosion;
    float step = 0;
    float rotateSpeed = 150;
    float speedBomb = 5;
    float angleToShip = 0;
    bool lockAngle = false;

	void Start () {

	}
	
	void Update () {
        Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
        angleToShip = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        if (fireAngle > -30f)
        {
            lockAngle = true;
            fireAngle = -30f;
        }
        else if (fireAngle < -150f || (fireAngle <= 180 && fireAngle > 0))
        {
            lockAngle = true;
            fireAngle = -150f;
        }

        if (lockAngle == false)
        {
            fireAngle = angleToShip;
        }

        step = speedBomb * Time.deltaTime;
        transform.Rotate(Vector3.forward * step * rotateSpeed);
        transform.position += new Vector3(Mathf.Cos(fireAngle * Mathf.Deg2Rad), Mathf.Sin(fireAngle * Mathf.Deg2Rad), 0) * step;
        if (transform.position.x > 8 || transform.position.x < -7 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "BombShot(Clone)")
        {
            BackFlash.flash = true;
            Destroy(this.gameObject);
            if (PlayerMovement.pierceCount + PlayerMovement.spreadCount + PlayerMovement.bombCount < 9)
            {
                if (PlayerMovement.pierceCount + PlayerMovement.spreadCount + PlayerMovement.bombCount == 8)
                    PlayerMovement.bombCount += 1;
                else
                    PlayerMovement.bombCount += 2;
            }
        }
        else if (col.gameObject.name == "PlayerSpaceShip")
        {
            Instantiate(thirdBossExplosion, transform.position, Quaternion.identity);
        }
        else
        {
            if (col.gameObject.name != "Explosion(Clone)")
                Destroy(col.gameObject);

            Instantiate(thirdBossExplosion, transform.position, Quaternion.identity);
        }
    }
}
