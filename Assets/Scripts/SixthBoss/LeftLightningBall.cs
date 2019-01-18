using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLightningBall : MonoBehaviour {
    Animator animator;
    public GameObject sideLightning;
    bool hasSet = false;

    IEnumerator callSideLightning()
    {
        animator.SetTrigger("ChargeUp");
        yield return new WaitForSeconds(0.417f);
        animator.SetTrigger("Pulse2");
        Instantiate(sideLightning, transform.position + new Vector3(0, -0.4f, 0), Quaternion.identity);
        yield return new WaitForSeconds(1.5f + 0.583f + 0.583f);
        animator.SetTrigger("ChargeDown");
        yield return new WaitForSeconds(0.417f);
        animator.SetTrigger("Pulse1");
    }

	void Start () {
        animator = GetComponent<Animator>();
	}

	void Update () {
        transform.position = GameObject.Find("SixthBoss").transform.position + new Vector3(-6.07f, -5.32f, 0f);
		if(SixthBossScript.whichBall == 1)
        {
            StartCoroutine(callSideLightning());
            SixthBossScript.whichBall = 0;
        }

        if (SixthBossScript.numCoresDestroyed >= 8)
        {
            if (hasSet == false)
            {
                hasSet = true;
                animator.SetTrigger("Exit");
                Destroy(this.gameObject, 0.917f);
            }
        }
    }
}
