using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {
    AudioSource aud;
    Animator animator;
    public float speed = 5;
    public GameObject rightShot, leftShot;
    public bool facingRight = false;
    bool hasFired = false;
    float delayUntilFire = 0f;

    IEnumerator fireShot()
    {
        yield return new WaitForSeconds(delayUntilFire);
        animator.SetTrigger("Fire");
        yield return new WaitForSeconds(5f / 12f);

        if (transform.position.y < 5.2f && transform.position.y > -5.2f)
        {
            aud.Play();
        }

        if (facingRight == false)
        {
            Instantiate(rightShot, transform.position + new Vector3(-1.85f, -0.12f, 0f), Quaternion.identity);
        }
        else
        {
            Instantiate(leftShot, transform.position + new Vector3(1.85f, 0.12f, 0f), Quaternion.identity);
        }
    }

	void Start () {
        delayUntilFire = Random.Range(0.0f, 0.5f);
        animator = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
	}

	void Update () {
        
        if(transform.position.y < 4 && transform.position.y > -3)
        {
            if(hasFired == false)
            {
                hasFired = true;
                StartCoroutine(fireShot());
            }
        }
        transform.position += Vector3.down * speed * Time.deltaTime;

        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
	}
}
