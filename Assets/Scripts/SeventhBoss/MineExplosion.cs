using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour {
    public GameObject upFireBurst, downFireBurst;
    float speed = 5f;

    IEnumerator spawnFireBurst()
    {
        yield return new WaitForSeconds((7f / 12f)/1.5f);
        Instantiate(upFireBurst, transform.position, Quaternion.identity);
        Instantiate(downFireBurst, transform.position, Quaternion.identity);
    }

	void Start () {
        Destroy(this.gameObject, 0.833f/1.5f);
        StartCoroutine(spawnFireBurst());
	}

	void Update () {
        transform.position += Vector3.down * speed * Time.deltaTime;
	}
}
