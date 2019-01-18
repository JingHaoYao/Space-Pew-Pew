using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserStarScript : MonoBehaviour {
    public float speedStar;
    public float rotateSpeed;
    float step;
    float angleMove = FirstBossScript.angleLaserStar;

    void Start()
    {
        
    }

    void Update()
    {
        step = speedStar * Time.deltaTime;

        transform.position += new Vector3(Mathf.Cos(angleMove * (Mathf.PI/180)), Mathf.Sin(angleMove * (Mathf.PI / 180)), 0) * step;
        transform.Rotate(Vector3.forward * step * rotateSpeed);
        if(transform.position.x > 8 || transform.position.x < -7 || transform.position.y > 5 || transform.position.y < -5)
        {
            FirstBossScript.launchingLaser = false;
            Destroy(this.gameObject);
        }
        else
        {
            FirstBossScript.launchingLaser = true;
        }

        if (GameObject.Find("BossExploding(Clone)"))
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "DuckyProjectile(Clone)" && col.gameObject.name != "FirstBoss" && col.gameObject.name
            != "BasicBlueEnemy(Clone)" && col.gameObject.name != "BasicRedEnemy(Clone)" && col.gameObject.name
            != "BasicGreenEnemy(Clone)" && col.gameObject.name != "LaserStar(Clone)" && col.gameObject.name != "FirstBossShield")
        {
            Destroy(this.gameObject);
        }
    }
}
