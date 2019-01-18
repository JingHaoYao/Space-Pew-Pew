using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollObstacle : MonoBehaviour {
    float downSpeed = 2;

    void Start () {
		if(SeventhBossScript.backGround1 == 1)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0);
        }
	}

	void Update () {
        transform.position += Vector3.down * downSpeed * Time.deltaTime;
		if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
	}
}
