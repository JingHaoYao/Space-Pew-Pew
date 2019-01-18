using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoTarget : MonoBehaviour {
    SpriteRenderer rend;
    public GameObject torpedo;
    
    IEnumerator blinkFireTorpedo()
    {
        for(int i = 0; i < 4; i++)
        {
            rend.enabled = false;
            yield return new WaitForSeconds(0.1f);
            rend.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        Instantiate(torpedo, transform.position + new Vector3(0, -8, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }

	void Start () {
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(blinkFireTorpedo());
	}

	void Update () {
		
	}
}
