using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthBossBulletScript : MonoBehaviour {
    float angleTravel = 0;
    float speedBullet = 10;
    float step = 0;
    public GameObject bulletDead;

	void Start () {
		if(FourthBossScript.whatTurretFire == 1)
        {
            angleTravel = Turret1Script.angle;
        }
        else if(FourthBossScript.whatTurretFire == 2)
        {
            angleTravel = Turret2Script.angle;
        }
        else if(FourthBossScript.whatTurretFire == 3)
        {
            angleTravel = Turret3Script.angle;
        }
        else if(FourthBossScript.whatTurretFire == 4)
        {
            angleTravel = Turret4Script.angle;
        }
	}

	void Update () {
        step = speedBullet * Time.deltaTime;
        transform.position += new Vector3(Mathf.Cos(angleTravel * Mathf.Deg2Rad), Mathf.Sin(angleTravel * Mathf.Deg2Rad), 0) * step;
        if(transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bulletDead, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
