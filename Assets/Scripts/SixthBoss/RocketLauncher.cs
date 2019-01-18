using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour {
    float speed = 5;
    float angle = 0;
    public float xDiff;
    public float yDiff;
    public int whichLauncher;
    public GameObject redRocket, blueRocket, greenRocket;
    GameObject[] rocketList;

    Animator animator;

    IEnumerator fireRockets()
    {
        yield return new WaitForSeconds(4f / 12f);
        for(int i = 0; i < 4; i++)
        {
            Instantiate(rocketList[Random.Range(0, 3)], transform.position + new Vector3(Mathf.Cos((angle - 90) * Mathf.Deg2Rad), Mathf.Sin((angle - 90) * Mathf.Deg2Rad),0) * (0.75f - (0.5f * i)), Quaternion.Euler(0, 0, angle + 90));
            yield return new WaitForSeconds(1 / 12f);
        }
    }

	void Start () {
        animator = GetComponent<Animator>();
        rocketList = new GameObject[] { redRocket, blueRocket, greenRocket };
	}

	void Update () {
        transform.position = GameObject.Find("SixthBoss").transform.position + new Vector3(xDiff, yDiff, 0);
        Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

        if(SixthBossScript.whichLauncher == whichLauncher)
        {
            animator.SetTrigger("RocketLaunch");
            StartCoroutine(fireRockets());
            SixthBossScript.whichLauncher = 0;
        }
        
    }
}
