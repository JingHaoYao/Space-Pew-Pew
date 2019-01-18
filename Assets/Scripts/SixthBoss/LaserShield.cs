using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShield : MonoBehaviour {
    AudioSource aud;
    Animator animator;
    SpriteRenderer rend;
    BoxCollider2D boxCol;
    public GameObject shieldLightning;
    bool hasSet = false;

    IEnumerator blink()
    {
        for(int i = 0; i < 4; i++)
        {
            rend.enabled = false;
            yield return new WaitForSeconds(0.05f);
            rend.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
        animator.SetTrigger("PhaseOut");
        aud.Play();
        boxCol.enabled = false;
        Destroy(this.gameObject, 0.417f);
    }

    void Start () {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        aud = GetComponent<AudioSource>();
	}

	void Update () {
        transform.position = GameObject.Find("SixthBoss").transform.position + new Vector3(0, -1.75f, 0);
        if(SixthBossScript.numCoresDestroyed >= 8)
        {
            if(hasSet == false)
            {
                StartCoroutine(blink());
                hasSet = true;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(shieldLightning, collision.gameObject.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
    }
}
