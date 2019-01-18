using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBulletPortal : MonoBehaviour {
    Animator animator;
    public GameObject blueSideFighter, greenSideFighter, redSideFighter, whiteSideFighter;
    GameObject[] fighterList;

    IEnumerator pulsing()
    {
        yield return new WaitForSeconds(0.417f);
        animator.SetTrigger("Pulsing");
        StartCoroutine(spawnShips());
    }

    IEnumerator phaseOut()
    {
        animator.SetTrigger("PhaseOut");
        yield return new WaitForSeconds(0.417f);
        Destroy(this.gameObject);
    }

    IEnumerator spawnShips()
    {
        for(int i = 0; i < 2; i++)
        {
            Instantiate(fighterList[Random.Range(0, 6)], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f + Random.Range(0,4) * 0.5f);
        }
        StartCoroutine(phaseOut());
    }

	void Start () {
        animator = GetComponent<Animator>();
        fighterList = new GameObject[] { blueSideFighter, greenSideFighter, redSideFighter, whiteSideFighter, whiteSideFighter, whiteSideFighter };
        StartCoroutine(pulsing());
	}

	void Update () {
		
	}
}
