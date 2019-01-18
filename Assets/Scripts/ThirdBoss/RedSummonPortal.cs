using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSummonPortal : MonoBehaviour {
    public GameObject bombShot;
    public static float angleShot = 0;
    IEnumerator summonBomb()
    {
        yield return new WaitForSeconds(0.416f);
        Instantiate(bombShot, transform.position, Quaternion.identity);
    }

    void Start()
    {
        Destroy(this.gameObject, 0.583f);
        StartCoroutine(summonBomb());
    }

    void Update()
    {
        Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
        angleShot = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
    }
}
