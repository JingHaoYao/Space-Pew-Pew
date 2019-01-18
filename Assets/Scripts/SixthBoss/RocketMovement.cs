using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour {
    public string whichColor = "";
    public GameObject explosion;
    Vector3 vectorToTarget = new Vector3();
    float angle = 0;
    public float speed = 8;

    void Start () {
        if(SixthBossScript.rocketNumber == 1)
        {
            vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - GameObject.Find("RocketLauncher1").transform.position;
        }
        else if(SixthBossScript.rocketNumber == 2)
        {
            vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - GameObject.Find("RocketLauncher2").transform.position;
        }
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x);
    }

	void Update () {
        transform.position += new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * Time.deltaTime * speed;
        if(transform.position.y < -9)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (PlayerMovement.spreadCount + PlayerMovement.pierceCount + PlayerMovement.bombCount < 9)
        {
            if (whichColor == "blue")
            {
                PlayerMovement.pierceCount++;
            }
            else if(whichColor == "green")
            {
                PlayerMovement.spreadCount++;
            }
            else
            {
                PlayerMovement.bombCount++;
            }
        }
        Destroy(this.gameObject);
    }
}
