using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFishScript : MonoBehaviour {
    float angleTravel = 0;
    float step = 0;
    float speedDart = 3;
    public GameObject fishDeath;

    void Start()
    {
        angleTravel = PirateCaptainScript.angleDart;
    }

    void Update()
    {
        step = speedDart * Time.deltaTime;
        transform.position += new Vector3(Mathf.Cos(angleTravel * Mathf.Deg2Rad), Mathf.Sin(angleTravel * Mathf.Deg2Rad), 0) * step;
        if (transform.position.y < -5 || transform.position.x > 8 || transform.position.x < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(fishDeath, transform.position, Quaternion.identity);
        if (PlayerMovement.spreadCount + PlayerMovement.pierceCount + PlayerMovement.bombCount < 9)
            PlayerMovement.bombCount++;
        Destroy(this.gameObject);
    }
}

