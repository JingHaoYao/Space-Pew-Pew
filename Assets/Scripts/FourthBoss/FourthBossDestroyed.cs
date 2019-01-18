using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthBossDestroyed : MonoBehaviour {
    public GameObject sideLightning1;
    public GameObject lightningEffect;

    IEnumerator spawnLightningEffects()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(sideLightning1, transform.position + new Vector3(-3.83f, 0, 0), Quaternion.Euler(0, 0, -90));
        Instantiate(sideLightning1, transform.position + new Vector3(4.82f, 0, 0), Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(0.333f);
        Instantiate(lightningEffect, transform.position, Quaternion.identity);
    }

	void Start(){
        StartCoroutine(spawnLightningEffects());
	}

	void Update(){
		
	}

}
