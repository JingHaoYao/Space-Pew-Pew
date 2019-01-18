using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceShotThirdBoss : MonoBehaviour {
    float speedBullet = 30;
    float step;
    float angleShot;
    float angleFire;
    float startTime = 0;

    void Start()
    {
        step = speedBullet * Time.deltaTime;
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime > 2)
        {
            transform.position += new Vector3(Mathf.Cos(angleFire * Mathf.Deg2Rad), Mathf.Sin(angleFire * Mathf.Deg2Rad), 0) * step;
        }
        else
        {
            Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
            angleShot = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angleShot + 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 7);
            angleFire = transform.transform.eulerAngles.z - 90;
        }

        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "PiercingShot(Clone)")
        {
            BackFlash.flash = true;
            Destroy(this.gameObject);
            if(PlayerMovement.pierceCount + PlayerMovement.spreadCount + PlayerMovement.bombCount < 9)
            {
                if(PlayerMovement.pierceCount + PlayerMovement.spreadCount + PlayerMovement.bombCount == 8)
                    PlayerMovement.pierceCount += 1;
                else
                    PlayerMovement.pierceCount += 2;
            }
        }
        else if(col.gameObject.name == "PlayerSpaceShip")
        {

        }
        else
        {
            if(col.gameObject.name != "Explosion(Clone)")
                Destroy(col.gameObject);
        }
    }
}
