using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStarScript : MonoBehaviour {
    float step = 0;
    float speed = 8;
    public GameObject laserBurst;
    bool hasSet = false;

	void Start () {
		
	}

	void Update () {
        step = speed * Time.deltaTime;
        if(transform.position.y <= -4.85f)
        {
            if(hasSet == false)
            {
                Destroy(this.gameObject);
                Instantiate(laserBurst, transform.position, Quaternion.identity);
                hasSet = true;
            }
        }
        transform.position += Vector3.down * step;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
