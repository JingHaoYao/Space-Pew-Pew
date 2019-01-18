using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSummonPortal : MonoBehaviour {
    public GameObject spreadShot;
    float angleShot = 0;
    public static float angleFire = 0;
    IEnumerator summonSpread()
    {
        yield return new WaitForSeconds(0.416f);
        for(int i = 0; i < 5; i++)
        {
            angleFire = angleShot - 20 + 10 * i;
            Instantiate(spreadShot, transform.position, Quaternion.Euler(0, 0, angleFire + 90));
        }
    }

    void Start()
    {
        Destroy(this.gameObject, 0.583f);
        StartCoroutine(summonSpread());
    }

    void Update()
    {
        Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
        angleShot = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
    }
}
