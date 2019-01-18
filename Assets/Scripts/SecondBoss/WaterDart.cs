using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDart : MonoBehaviour {
    float angleTravel = 0;
    float step = 0;
    float speedDart = 3;
    public GameObject waterExplosion;

    void Start() {
        angleTravel = PirateCaptainScript.angleDart;
    }

    void Update()
    {
        step = speedDart * Time.deltaTime;
        transform.position += new Vector3(Mathf.Cos(angleTravel * Mathf.Deg2Rad), Mathf.Sin(angleTravel * Mathf.Deg2Rad), 0) * step;
        if (transform.position.y < -4.5 || transform.position.x > 7.85 || transform.position.x < -6.85)
        {
            if (transform.position.y < -4.5)
            {
                Instantiate(waterExplosion, transform.position + new Vector3(0, -0.5f, 0), Quaternion.Euler(0, 0, 360));
            }
            else if (transform.position.x > 7.85)
            {
                Instantiate(waterExplosion, transform.position + new Vector3(0, -0.5f, 0), Quaternion.Euler(0, 0, 90));
            }
            else
            {
                Instantiate(waterExplosion, transform.position + new Vector3(0, -0.5f, 0), Quaternion.Euler(0, 0, 270));
            }
            Destroy(this.gameObject);
        }  
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(waterExplosion, transform.position + new Vector3(0.5f*Mathf.Cos(angleTravel*Mathf.Deg2Rad), 0.5f*Mathf.Sin(angleTravel*Mathf.Deg2Rad), 0), Quaternion.Euler(0,0,angleTravel + 90));
        Destroy(this.gameObject);
    }
}

