using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthBossDefeated : MonoBehaviour {
    Animator animator;

    IEnumerator animate()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Defeated2");
    }

	void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine(animate());
        FifthBossFadeInOut.fadeOut = true;
	}

	void Update () {
		
	}
}
