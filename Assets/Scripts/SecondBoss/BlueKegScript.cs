using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKegScript : MonoBehaviour {
    public float speedKeg;
    public float kegRotateSpeed;
    float step;
    int whatAngle = 0;
    public GameObject blueKegExplosion;

    void Start()
    {
        whatAngle = Random.Range(45, 67);
    }

    void Update()
    {
        step = speedKeg * Time.deltaTime;
        transform.position += new Vector3(Mathf.Cos(whatAngle*5*Mathf.Deg2Rad),Mathf.Sin(whatAngle*5*Mathf.Deg2Rad),0) * step;
        transform.Rotate(Vector3.forward * step * kegRotateSpeed);
        if(transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "PirateCannon1" && col.gameObject.name != "PirateCannon2" && col.gameObject.name !=
            "PirateCannon3" && col.gameObject.name != "BuccaneerShot(Clone)" && col.gameObject.name != "SecondBoss")
        {
            Destroy(this.gameObject);
            if (PlayerMovement.spreadCount + PlayerMovement.pierceCount + PlayerMovement.bombCount < 9)
                PlayerMovement.pierceCount++;
            Instantiate(blueKegExplosion, this.transform.position, Quaternion.identity);
        }
    }
}
