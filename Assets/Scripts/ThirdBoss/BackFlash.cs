using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFlash : MonoBehaviour {
    Animator animator;
    public static bool flash = false;

    IEnumerator revealBoss()
    {
        LightningClash.revealBoss = true;
        yield return new WaitForSeconds(2f);
        LightningClash.revealBoss = false;
    }

	void Start () {
        animator = GetComponent<Animator>();
	}

	void Update () {
	    if(flash == true)
            {
            StartCoroutine(revealBoss());
            flash = false;
            animator.SetTrigger("Flash");
            CameraShake.shakeCam = true;
        }	
	}
}
