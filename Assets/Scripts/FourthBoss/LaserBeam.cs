using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour {
    Animator animator;
    AudioSource audioSource;
    SpriteRenderer rend;
    BoxCollider2D boxCol;
    bool hasSet = false;

    IEnumerator blinking()
    {
        animator.SetTrigger("ChargeUp");
        yield return new WaitForSeconds(0.75f / 2f);
        animator.SetTrigger("FireLaser");
        audioSource.Play();
        boxCol.enabled = true;
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("ChargeDown");
        audioSource.Pause();
        boxCol.enabled = false;
        yield return new WaitForSeconds(0.75f / 2f);
        FourthBossFireLaser.firedLaser = true;
        hasSet = false;
        Destroy(this.gameObject);
    }

	void Start () {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        boxCol.enabled = false;
	}

	void Update () {
		if(hasSet == false)
        {
            StartCoroutine(blinking());
            hasSet = true;
        }
	}
}
