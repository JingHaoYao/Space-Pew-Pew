using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StasisShip : MonoBehaviour {
    AudioSource audioSource;
    Animator animator;
    SpriteRenderer rend;
    BoxCollider2D boxCol;
    public GameObject stasisShot;
    bool dontFire = false;
    bool isMovingRight = false;
    float sideSpeed = 6;
    bool exitScreen = false;
    bool hasSet = false;
    int health = 3;
    
    IEnumerator blink()
    {
        for(int i = 0; i < 2; i++)
        {
            rend.enabled = false;
            yield return new WaitForSeconds(0.05f);
            rend.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator fireStasis()
    {
        yield return new WaitForSeconds(7f);
        boxCol.enabled = false;
        if(dontFire == false)
        {
            animator.SetTrigger("Fire");
            yield return new WaitForSeconds(4f / 12f);
            Instantiate(stasisShot, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f - 0.333f);
            animator.SetTrigger("Neutral");
        }
        exitScreen = true;
    }

	void Start () {
        animator = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
	}

	void Update () {
        if (exitScreen == false)
        {
            if (transform.position.y > 4)
            {
                transform.position += Vector3.down * Time.deltaTime * 5;
            }
            else
            {
                if(hasSet == false)
                {
                    hasSet = true;
                    StartCoroutine(fireStasis());
                }

                sideSpeed = 6 - ((Mathf.Abs(0.5f - transform.position.x)) * 0.5f);
                if (isMovingRight)
                {
                    transform.position += Vector3.right * sideSpeed * Time.deltaTime;
                    if (transform.position.x >= 6.3f)
                    {

                        isMovingRight = false;
                    }
                }
                else
                {
                    transform.position += Vector3.left * sideSpeed * Time.deltaTime;
                    if (transform.position.x <= -5.3f)
                    {
                        isMovingRight = true;
                    }
                }
                Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10);
            }
        }
        else
        {
            if(transform.position.y < 6)
            {
                transform.position += Vector3.up * Time.deltaTime * 5;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;
        if (health <= 0)
        {
            audioSource.Play();
            boxCol.enabled = false;
            animator.SetTrigger("Destroyed");
            dontFire = true;
            Destroy(this.gameObject, 0.917f);
        }
        else
        {
            StartCoroutine(blink());
        }
    }
}
