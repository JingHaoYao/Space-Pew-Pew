using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhBossEnd : MonoBehaviour {
    float period1 = 0;
    float slowFactor = 1;
    public float yStart = 75;
    bool start = false;

    bool hasSet = false;

    IEnumerator waitTillStart()
    {
        yield return new WaitForSeconds(6f);
        start = true;
    }

	void Start () {

	}

	void Update () {
        if(hasSet == false)
        {
            hasSet = true;
            StartCoroutine(waitTillStart());
        }

        if (start == true)
        {
            if (slowFactor > 0)
            {
                slowFactor -= 0.2f * Time.deltaTime;
            }
            else
            {
                slowFactor = 0;
                FadeInOutSeventhBoss.fadeOut = true;
            }
            period1 += Time.deltaTime * slowFactor;
            transform.position = Vector3.up * yStart + Vector3.down * period1 * 30;
        }
    }
}
