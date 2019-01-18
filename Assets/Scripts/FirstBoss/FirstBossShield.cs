using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossShield : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite shield1;
    Animator animator;
    CircleCollider2D hitbox;
    public GameObject darkHoleEffect;
    bool hasAdvanced = false;
    public float speedShield;
    bool movingRight = true;
    bool hasPhased = false;
    Vector3 centre = new Vector3(0.5f,5,0);
    float angle = Mathf.PI-Mathf.PI/6;

    void advanceToScreen()
    {
        float step = speedShield * Time.deltaTime;
        transform.position += Vector3.down * step;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = shield1;
        animator = GetComponent<Animator>();
        hitbox = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        float step = speedShield * Time.deltaTime;
        if (FirstBossScript.bossHealth > 10)
        {
            transform.position = GameObject.Find("FirstBoss").transform.position;
            hitbox.enabled = false;
            spriteRenderer.enabled = false;
        }
        else
        {
            centre = GameObject.Find("FirstBoss").transform.position + new Vector3(0,1.5f,0);
            spriteRenderer.enabled = true;
            hitbox.enabled = true;
            if (hasPhased == false)
            {
                animator.SetTrigger("PhaseIn");
                hasPhased = true;
            }

            if (!movingRight)
            {
                angle -= speedShield * Time.deltaTime;
                if(angle <= Mathf.PI - Mathf.PI / 6)
                {
                    movingRight = true;
                }
            }
            else
            {
                angle += speedShield * Time.deltaTime;
                if(angle >= 2*Mathf.PI + Mathf.PI/6)
                {
                    movingRight = false;
                }
            }
            Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * 4.5f;
            transform.position = centre + offset;
        }

        if(FirstBossScript.bossHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "DuckyProjectile(Clone)" && collision.gameObject.name != "EnemyBullet(Clone)"
            && collision.gameObject.name != "FirstBoss" && collision.gameObject.name != "LaserStar(Clone)" &&
            collision.gameObject.name != "DuckyExplosion(Clone)" && collision.gameObject.name != "BlueDuckyProjectile(Clone)" 
            && collision.gameObject.name != "RedDuckyProjectile(Clone)" && collision.gameObject.name != 
            "GreenDuckyProjectile(Clone)")
        {
            if (collision.gameObject.name == "DuckyExplosion(Clone)" || collision.gameObject.name == "FirstBoss" 
                || collision.gameObject.name == "DuckyProjectile(Clone)")
            {
            }
            else
            {
                Instantiate(darkHoleEffect, collision.gameObject.transform.position + new Vector3(0,0.7f,0), Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }
    }
}
