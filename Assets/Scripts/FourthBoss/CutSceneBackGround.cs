using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneBackGround : MonoBehaviour {
    Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("FadeOut");
            Destroy(this.gameObject, 0.833f);
        }
    }
}
