using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCell : MonoBehaviour {

    public static int cellHealth = 20;
    Animator animator;
    AudioSource aud;

    IEnumerator hitFrames()
    {
        animator.SetTrigger("LightningCell");
        yield return new WaitForSeconds(0.667f / 2f);
        animator.SetTrigger("Pulse");
    }

	void Start () {
        aud = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
	}

	void Update () {
        transform.position = GameObject.Find("SixthBoss").transform.position + new Vector3(0, 1.27f, 0);
        if(cellHealth <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aud.Play();
        cellHealth--;
        StartCoroutine(hitFrames());
    }
}
