using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadThirdBoss : MonoBehaviour {
    Animator animator;
    public static bool disentegrate = false;

	void Start(){
        CheckPoints.passedThirdCheckpoint = true;
        animator = GetComponent<Animator>();
	}

	void Update(){
		if(disentegrate == true)
        {
            disentegrate = false;
            animator.SetTrigger("Disappear");
            Destroy(this.gameObject, 0.667f);
        }
	}
}
