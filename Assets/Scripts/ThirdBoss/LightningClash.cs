using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningClash : MonoBehaviour {
    public static bool revealBoss = false;

	void Start(){
        Destroy(this.gameObject, 2f);
        revealBoss = true;
        CameraShake.shakeCam = true;
    }

	void Update(){
		
	}

    private void OnDestroy()
    {
        revealBoss = false;
    }
}
