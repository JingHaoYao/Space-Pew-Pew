using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMeteorScript : MonoBehaviour {
    Vector3 origPosition = new Vector3(0, 0, 0);
    CircleCollider2D circCol;
    AudioSource audioSource;
    Animator animator;
    float speed = 4;
    float rotateSpeed = 100;

    void moveRight()
    {
        float step = speed * Time.deltaTime;
        transform.position += Vector3.right * step;
        if (transform.position.x > 8.5f)
        {
            Destroy(this.gameObject);
        }
        transform.Rotate(Vector3.forward * step * rotateSpeed);
    }

    void moveLeft()
    {
        float step = speed * Time.deltaTime;
        transform.position += Vector3.left * step;
        if (transform.position.x < -8.5f)
        {
            Destroy(this.gameObject);
        }
        transform.Rotate(Vector3.forward * step * rotateSpeed);
    }

    void Start()
    {
        circCol = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        origPosition = transform.position;
        speed = Random.Range(3, 7);
        rotateSpeed = speed * 10 + 20;
    }

    void Update()
    {
        if (origPosition.x < 0)
        {
            moveRight();
        }
        else
        {
            moveLeft();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "BackBasePlate" && collision.gameObject.name != "FrontBasePlate")
        {
            audioSource.Play();
            circCol.enabled = false;
            animator.SetTrigger("Explode");
            Destroy(this.gameObject, 0.583f);
            if (PlayerMovement.bombCount + PlayerMovement.pierceCount + PlayerMovement.spreadCount < 9)
            {
                PlayerMovement.spreadCount++;
            }
        }
    }
}
