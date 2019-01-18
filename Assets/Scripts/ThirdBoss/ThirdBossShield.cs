using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBossShield : MonoBehaviour {
    CircleCollider2D col;
    SpriteRenderer rend;
    Animator animator;
    bool shieldBroke = false, shieldReformed = false;
    public GameObject lightningZap;

	void Start () {
        rend = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
	}

	void Update () {
        transform.position = GameObject.Find("ThirdBoss").transform.position;
        if(ThirdBossScript.shieldOff == true)
        {
            col.enabled = false;
            if (shieldBroke == false)
            {
                animator.SetTrigger("BreakShield");
                shieldBroke = true;
                shieldReformed = false;
            }
        }
        else
        {
            col.enabled = true;
            if (shieldReformed == false)
            {
                animator.SetTrigger("ReformShield");
                shieldReformed = true;
                shieldBroke = false;
            }
        }

        if (ThirdBossScript.spiritBossHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(lightningZap, collision.gameObject.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
    }
}
