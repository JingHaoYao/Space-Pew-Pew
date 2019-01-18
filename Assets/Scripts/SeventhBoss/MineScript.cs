using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour {
    float downSpeed = 5;
    float rotateSpeed = 120;
    public GameObject explosion;
    public string whatColor = "";

	void Start () {
		
	}

    void Update () {
        transform.position += Vector3.down * downSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.y < 5.5f && transform.position.y > -5.5f)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            if (PlayerMovement.bombCount + PlayerMovement.pierceCount + PlayerMovement.spreadCount < 9)
            {
                if (whatColor == "red")
                {
                    PlayerMovement.bombCount++;
                }
                else if (whatColor == "blue")
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
}
