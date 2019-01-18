using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLightningEffect : MonoBehaviour {
    Animator animator;
    float period = 0;

    IEnumerator startEffect()
    {
        yield return new WaitForSeconds(0.417f);
        animator.SetTrigger("StartEffect");
    }

	void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine(startEffect());
	}

	void Update () {
        period += Time.deltaTime;
        transform.localScale += new Vector3(period/1300, period/1300, 0);
    }
}
