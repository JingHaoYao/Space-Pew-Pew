using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBossExplosion : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 1.083f / 1.5f);
	}

	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "PlayerSpaceShip")
        {

        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
