using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSideFighter : MonoBehaviour {
    float step = 0;
    float speed = 3;
    public GameObject starBullet, explosion;
    float waitDuration = 0;

    IEnumerator fireBullet()
    {
        yield return new WaitForSeconds(waitDuration);
        Instantiate(starBullet, transform.position, Quaternion.identity);
    }

    void Start()
    {
        waitDuration = Random.Range(0.5f, 2.5f);
        StartCoroutine(fireBullet());
    }

    void Update()
    {
        if (speed < 6)
        {
            speed += Time.deltaTime * 2;
        }

        step = Time.deltaTime * speed;
        if (FifthBoss.comingLeft)
        {
            transform.position += Vector3.right * step;
            if (transform.position.x > 9)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0);
            transform.position += Vector3.left * step;
            if (transform.position.x < -9)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerMovement.pierceCount + PlayerMovement.spreadCount + PlayerMovement.bombCount < 9)
        {
            PlayerMovement.bombCount++;
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
