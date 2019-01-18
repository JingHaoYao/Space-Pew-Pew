using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLineEnd : MonoBehaviour {
    float step = 0;
    float speed = 5;
    bool hasSet = false;
    public GameObject laserLine;
    float period = 0;
    bool flownIn = false;

	void Start () {
		
	}

	void Update () {
        step = speed * Time.deltaTime;
		if(transform.position.y > 3.5f && flownIn == false)
        {
            transform.position += Vector3.down * step;
        }
        else
        {
            period += Time.deltaTime;
            if(hasSet == false)
            {
                Instantiate(laserLine, transform.position - new Vector3(0, 6.7f, 0), Quaternion.identity);
                flownIn = true;
                hasSet = true;
            }

            if(period >= FifthBoss.laserLineDuration + 0.5f)
            {
                if(transform.position.y < 6)
                {
                    transform.position += Vector3.up * step;
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
	}
}
