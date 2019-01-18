using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoExplosion : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 1.083f);
	}

	void Update () {
        transform.position += Vector3.down * Time.deltaTime * 5;
	}
}
