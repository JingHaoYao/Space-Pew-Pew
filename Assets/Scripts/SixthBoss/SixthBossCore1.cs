using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossCore1 : MonoBehaviour {
    AudioSource aud;
    SpriteRenderer rend;
    public Sprite blueCore, greenCore, redCore, destroyedCore;
    Sprite[] spriteList;
    public GameObject coreExplosion;
    BoxCollider2D boxCol;
    int whichColor = 0;
    public float yDiff = 0;
    public float xDiff = 0;
    bool hasSet = false;

	void Start () {
        rend = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        aud = GetComponent<AudioSource>();
        whichColor = Random.Range(0, 3);
        boxCol.enabled = false;
        spriteList = new Sprite[] { blueCore, greenCore, redCore };
        rend.sprite = spriteList[whichColor];
	}

	void Update () {
        if(SixthBossScript.bossFightStarted == true && hasSet == false)
        {
            boxCol.enabled = true;
            hasSet = true;
        }
        transform.position = GameObject.Find("SixthBoss").transform.position + new Vector3(xDiff, yDiff, 0);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (whichColor == 0 && collision.gameObject.name == "PiercingShot(Clone)")
        {
            Instantiate(coreExplosion, transform.position, Quaternion.identity);
            aud.Play();
            rend.sprite = destroyedCore;
            SixthBossScript.numCoresDestroyed++;
            boxCol.enabled = false;
        }

        if (whichColor == 1 && (collision.gameObject.name == "SpreadShotMid(Clone)" || collision.gameObject.name == "SpreadShotLeft(Clone)" 
            || collision.gameObject.name == "SpreadShotRight(Clone)"))
        {
            Instantiate(coreExplosion, transform.position, Quaternion.identity);
            aud.Play();
            rend.sprite = destroyedCore;
            SixthBossScript.numCoresDestroyed++;
            boxCol.enabled = false;
        }

        if(whichColor == 2 && collision.gameObject.name == "BombShot(Clone)")
        {
            Instantiate(coreExplosion, transform.position, Quaternion.identity);
            aud.Play();
            rend.sprite = destroyedCore;
            SixthBossScript.numCoresDestroyed++;
            boxCol.enabled = false;
        }
    }
}
