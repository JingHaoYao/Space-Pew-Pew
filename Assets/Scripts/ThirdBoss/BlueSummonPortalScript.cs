using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSummonPortalScript : MonoBehaviour {
    public GameObject laserSpear;
    IEnumerator summonSpear()
    {
        yield return new WaitForSeconds(0.416f);
        Instantiate(laserSpear, transform.position, Quaternion.identity);
    }

	void Start () {
        Destroy(this.gameObject, 0.583f);
        StartCoroutine(summonSpear());
	}
	
	void Update () {
		
	}
}
