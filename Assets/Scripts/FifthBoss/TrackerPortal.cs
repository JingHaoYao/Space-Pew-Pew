using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerPortal : MonoBehaviour {
    Animator animator;
    public GameObject blueTracker, greenTracker, redTracker, whiteTracker;
    GameObject[] trackerList;

    IEnumerator spawnBomb()
    {
        yield return new WaitForSeconds(0.417f);
        animator.SetTrigger("Pulsing");
        Instantiate(trackerList[Random.Range(0, 6)], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        animator.SetTrigger("PhaseOut");
        yield return new WaitForSeconds(0.417f);
        Destroy(this.gameObject);
    }

	void Start () {
        animator = GetComponent<Animator>();
        trackerList = new GameObject[] { blueTracker, greenTracker, redTracker, whiteTracker, whiteTracker, whiteTracker };
        StartCoroutine(spawnBomb());
	}

	void Update () {
		
	}
}
