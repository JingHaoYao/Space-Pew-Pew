using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCrack : MonoBehaviour {
    Vector3 crackStartPosition, shipStartPosition;

	void Start(){
        crackStartPosition = transform.position;
        shipStartPosition = GameObject.Find("SecondBoss").transform.position;
        Destroy(gameObject, 6);
	}

    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }

    void Update(){
        if (GameObject.Find("PirateShipBaseBurning(Clone)"))
        {
            transform.position = crackStartPosition + (GameObject.Find("PirateShipBaseBurning(Clone)").transform.position - shipStartPosition);
            if (GameObject.Find("ShipIsDestroyedExplosion(Clone)"))
            {
                StartCoroutine(delayDestroy());
            }
        }

        transform.position = crackStartPosition + (GameObject.Find("SecondBoss").transform.position - shipStartPosition);
    }
}
