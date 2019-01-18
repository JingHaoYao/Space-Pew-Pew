using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEffect : MonoBehaviour {
    SpriteRenderer rend;
    Animator animator;
    public static bool startLightningEffect = false;
    public static bool endLightningEffect = false;
    public GameObject ALI, fToAdvance;

	void Start () {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
        fToAdvance.SetActive(false);
        ALI.SetActive(false);
    }

	void Update () {
		if(startLightningEffect == true)
        {
            rend.enabled = true;
            animator.SetTrigger("LightningPhaseIn");
            startLightningEffect = false;
        }

        if (endLightningEffect == true){
            Destroy(this.gameObject);
            ALI.SetActive(true);
            fToAdvance.SetActive(true);
        }
	}
}
