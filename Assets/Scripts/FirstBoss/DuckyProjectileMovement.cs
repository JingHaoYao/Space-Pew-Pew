using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckyProjectileMovement : MonoBehaviour {

    public float speedDucky;
    public float duckyRotateSpeed;
    float step;
    public GameObject duckyExplosion;

    void Start()
    {
        Destroy(gameObject, 10 / speedDucky);
    }

    void Update()
    {

        step = speedDucky * Time.deltaTime;
        transform.position += Vector3.down * step;
        transform.Rotate(Vector3.forward * step * duckyRotateSpeed);
        if (GameObject.Find("BossExploding(Clone)"))
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "DuckyProjectile(Clone)" && col.gameObject.name != "FirstBoss" && col.gameObject.name 
            != "BasicBlueEnemy(Clone)" &&  col.gameObject.name != "BasicRedEnemy(Clone)" && col.gameObject.name 
            != "BasicGreenEnemy(Clone)" && col.gameObject.name != "FirstBossShield")
        {
            Destroy(this.gameObject);
            Instantiate(duckyExplosion, this.transform.position, Quaternion.identity);
        }
    }
}
