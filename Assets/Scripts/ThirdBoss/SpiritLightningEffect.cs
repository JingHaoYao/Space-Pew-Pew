using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritLightningEffect : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        transform.position = GameObject.Find("ThirdBossSpirit(Clone)").transform.position;
        if(ShipSpirit.growLightning == true)
        {
            ShipSpirit.growLightning = false;
            transform.localScale += new Vector3(0.03f, 0.03f, 0);
        }
	}
}
