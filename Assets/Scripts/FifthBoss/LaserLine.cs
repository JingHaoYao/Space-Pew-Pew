using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLine : MonoBehaviour {
    Animator animator;
    BoxCollider2D boxCol;
    AudioSource audioSource;

    IEnumerator laserLine()
    {
        boxCol.enabled = false;
        yield return new WaitForSeconds(0.417f);
        animator.SetTrigger("LaserLine");
        boxCol.enabled = true;
        yield return new WaitForSeconds(FifthBoss.laserLineDuration - 0.5f);
        audioSource.Play();
        boxCol.enabled = false;
        animator.SetTrigger("PhaseOut");
        yield return new WaitForSeconds(0.417f);
        Destroy(this.gameObject);
    }

	void Start () {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        StartCoroutine(laserLine());
	}

	void Update () {
		
	}
}
