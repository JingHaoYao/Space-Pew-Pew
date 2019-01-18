using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour {
    public GameObject leftFireBall, rightFireBall, middleFireball;

    IEnumerator sprayFire()
    {
        yield return new WaitForSeconds(7f / 12f);
        fireBallFire();
    }

    void fireBallFire()
    {
        Instantiate(leftFireBall, transform.position, Quaternion.Euler(0, 0, -120 + 90));
        Instantiate(middleFireball, transform.position, Quaternion.Euler(0, 0, -90 + 90));
        Instantiate(rightFireBall, transform.position, Quaternion.Euler(0, 0, -60 + 90));
    }

	void Start () {
        Destroy(this.gameObject, 0.833f);
        StartCoroutine(sprayFire());
	}

	void Update () {
		
	}
}
