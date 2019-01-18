using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCoreScript : MonoBehaviour {
    CircleCollider2D circCol;

	void Start () {
        circCol = GetComponent<CircleCollider2D>();
	}

	void Update () {
		if(AliDialogue.opportunityGone == true)
        {
            circCol.enabled = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyedFlash.flashOn = true;
        AliDialogue.coreShot = true;
        circCol.enabled = false;
    }
}
