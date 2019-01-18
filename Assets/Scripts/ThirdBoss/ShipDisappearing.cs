using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDisappearing : MonoBehaviour {
    Animator animator;
    public static bool fadeAway = false;

	void Start () {
        animator = GetComponent<Animator>();
	}

	void Update () {
		if(fadeAway == true)
        {
            fadeAway = false;
            animator.SetTrigger("Disappear");
            Destroy(this.gameObject, 0.667f);
        }
	}
}
