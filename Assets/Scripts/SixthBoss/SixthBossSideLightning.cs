using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossSideLightning : MonoBehaviour {
    Animator animator;
    BoxCollider2D boxCol;

    IEnumerator flashLightning()
    {
        yield return new WaitForSeconds(0.583f);
        animator.SetTrigger("Pulse");
        boxCol.enabled = true;
        yield return new WaitForSeconds(1.5f);
        animator.SetTrigger("ChargeDown");
        boxCol.enabled = false;
        yield return new WaitForSeconds(0.583f);
        Destroy(this.gameObject);
    }

    void Start () {
        animator = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        boxCol.enabled = false;
        StartCoroutine(flashLightning());
    }


	void Update () {
		if(SixthBossScript.numCoresDestroyed >= 8)
        {
            Destroy(this.gameObject);
        }
	}
}
