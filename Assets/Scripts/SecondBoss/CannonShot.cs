using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour {
    float speedShot = 20;
    float step;

    void Start()
    {
        step = speedShot * Time.deltaTime;
    }

    void Update()
    {
        transform.position += Vector3.down * step;

        if (transform.position.y < -5)
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
