using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StasisShot : MonoBehaviour {
    float speed = 10;
    bool hasSet = false;

    public GameObject stasisLock;

	void Start () {
		
	}

	void Update () {
        float step = speed * Time.deltaTime;
        Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
        float angleToShip = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.position += new Vector3(Mathf.Cos(angleToShip * Mathf.Deg2Rad), Mathf.Sin(angleToShip * Mathf.Deg2Rad), 0) * step;
        transform.rotation = Quaternion.Euler(0, 0, angleToShip + 90);
        if (Mathf.Sqrt(Mathf.Pow(vectorToTarget.x, 2) + Mathf.Pow(vectorToTarget.y, 2)) < 0.1 && hasSet == false)
        {
            Instantiate(stasisLock, GameObject.Find("PlayerSpaceShip").transform.position, Quaternion.identity);
            hasSet = true;
            Destroy(this.gameObject);
        }
    }
}
