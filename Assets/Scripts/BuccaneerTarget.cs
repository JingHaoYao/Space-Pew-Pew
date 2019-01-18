using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuccaneerTarget : MonoBehaviour {
    SpriteRenderer rend;

    IEnumerator displayTarget()
    {
        for(int i = 0; i < 11; i++)
        {
            rend.enabled = true;
            yield return new WaitForSeconds(0.15f);
            rend.enabled = false;
            yield return new WaitForSeconds(0.15f);
        }
    }

	void Start(){
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
	}

	void Update(){
        transform.position = GameObject.Find("PlayerSpaceShip").transform.position;
        if (BuccaneerShooterScript.charging)
        {
            StartCoroutine(displayTarget());
            BuccaneerShooterScript.charging = false;
        }
	}
}
