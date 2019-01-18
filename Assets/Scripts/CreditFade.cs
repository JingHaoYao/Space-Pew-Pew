using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditFade : MonoBehaviour {
    float period = 0;
    Animator animator;
    bool hasSet = false;

	void Start () {
        animator = GetComponent<Animator>();
	}

	void Update () {
        period += Time.deltaTime;

		if(period >= 9)
        {
            if (hasSet == false)
            {
                animator.SetTrigger("FadeOut");
                Destroy(this.gameObject, 1f);
                hasSet = true;
            }
        }
	}
}
