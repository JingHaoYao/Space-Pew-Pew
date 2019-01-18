using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInCutScene : MonoBehaviour {
    Animator animator;
        
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetTrigger("FadeIn");
	}

	void Update () {
		
	}
}
