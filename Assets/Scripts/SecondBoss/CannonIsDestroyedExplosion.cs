using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonIsDestroyedExplosion : MonoBehaviour {
    Vector3 explosionStartPosition;
    Vector3 shipStartPosition;
    
	void Start(){
        explosionStartPosition = transform.position;
        shipStartPosition = GameObject.Find("SecondBoss").transform.position;
        Destroy(gameObject, 0.583f);
	}
	
	void Update(){
        transform.position = explosionStartPosition + (GameObject.Find("SecondBoss").transform.position - shipStartPosition);
	}
}
