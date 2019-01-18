using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrackerScript : MonoBehaviour {
    CircleCollider2D circCol;
    public GameObject explosion;
    float step = 0;
    float rotateSpeed = 150;
    float speedBomb = 1;
    float angleToShip = 0;
    bool lockAngle = false;
    float fireAngle = 0;

    void Start()
    {
        circCol = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (speedBomb < 5)
        {
            speedBomb += Time.deltaTime * 2;
        }

        Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
        angleToShip = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        if (lockAngle == false)
        {
            fireAngle = angleToShip;
        }

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

        step = speedBomb * Time.deltaTime;
        transform.Rotate(Vector3.forward * step * rotateSpeed);
        transform.position += new Vector3(Mathf.Cos(fireAngle * Mathf.Deg2Rad), Mathf.Sin(fireAngle * Mathf.Deg2Rad), 0) * step;

        if (transform.position.x > 8 || transform.position.x < -7 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        circCol.enabled = false;
        Destroy(this.gameObject);
        if (PlayerMovement.spreadCount + PlayerMovement.pierceCount + PlayerMovement.bombCount < 9)
        {
            PlayerMovement.bombCount++;
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
