using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSideBar : MonoBehaviour {
    Animator animator;
    public static bool fadeAway = false;

	void Start () {
        animator = GetComponent<Animator>();
        PlayerMovement.overClocked = true;
    }

	void Update () {
		if(fadeAway == true)
        {
            fadeAway = false;
            animator.SetTrigger("LightningBarAway");
            Destroy(this.gameObject, 1f);
        }
	}
}
