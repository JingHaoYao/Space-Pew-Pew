using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipIsDestroyedExplosion : MonoBehaviour {
    Vector3 explosionStartPosition;
    Vector3 shipStartPosition;

    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(GameObject.Find("PirateShipBurning(Clone)"));
    }

    void Start()
    {
        StartCoroutine(delayDestroy());
        Destroy(gameObject, 0.583f);
    }

    void Update()
    {

    }
}
