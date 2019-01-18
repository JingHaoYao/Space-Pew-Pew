using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPortal : MonoBehaviour {
    Animator animator;

    IEnumerator spawnPortal()
    {
        yield return new WaitForSeconds(0.417f);
        animator.SetTrigger("Pulsing");
        yield return new WaitForSeconds(0.45f);
        animator.SetTrigger("PhaseOut");
        yield return new WaitForSeconds(0.417f);
        Destroy(this.gameObject);
    }

	void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine(spawnPortal());
	}

	void Update () {
		
	}
}
