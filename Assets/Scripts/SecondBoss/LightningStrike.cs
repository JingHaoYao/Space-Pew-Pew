using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour {
    public static bool lightningFlashOn = false;
    SpriteRenderer rend;

	void Start(){
        rend = GetComponent<SpriteRenderer>();
	}
	
	void Update(){
		if(lightningFlashOn == true)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }
	}
}
