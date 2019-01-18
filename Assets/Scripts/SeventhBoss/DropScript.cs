using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour {
    AudioSource aud;
    Vector3 startPosition;
    public string whatColor = "";
    float randAngle = 0;
    float downSpeed = 5;
    float sideSpeed = 3;
    float rotateSpeed = 100;

	void Start () {
        startPosition = transform.position;
        aud = GetComponent<AudioSource>();
        randAngle = Random.Range(90f, 270f);
	}

	void Update ()
    {
        transform.position += Vector3.down * downSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        if (startPosition.x > 0)
        {
            transform.position += new Vector3(Mathf.Cos(randAngle * Mathf.Deg2Rad), Mathf.Sin(randAngle * Mathf.Deg2Rad), 0) * sideSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(Mathf.Cos((randAngle + 180) * Mathf.Deg2Rad), Mathf.Sin((randAngle + 180) * Mathf.Deg2Rad), 0) * sideSpeed * Time.deltaTime;
        }

        if(transform.position.x < -9f || transform.position.x > 9f || transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aud.Play();
        if (PlayerMovement.bombCount + PlayerMovement.pierceCount + PlayerMovement.spreadCount < 9)
        {
            if (whatColor == "red")
            {
                PlayerMovement.bombCount++;
            }
            else if(whatColor == "blue")
            {
                PlayerMovement.pierceCount++;
            }
            else
            {
                PlayerMovement.spreadCount++;
            }
        }
        Destroy(this.gameObject);
    }
}
