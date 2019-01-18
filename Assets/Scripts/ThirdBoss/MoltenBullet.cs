using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoltenBullet : MonoBehaviour {
    Animator animator;
    CircleCollider2D col;
    float step = 0;
    float rotateSpeed = 120;
    float speedOfMeteor = 10;
    float fireAngle = 0;
    public GameObject lavaBurst;
    AudioSource audioSource;

	void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        col = GetComponent<CircleCollider2D>();
        fireAngle = Random.Range(-120f, -60f);
	}
	
	void Update () {
        step = speedOfMeteor * Time.deltaTime;
        transform.Rotate(Vector3.forward * step * rotateSpeed);
        transform.position += new Vector3(Mathf.Cos(fireAngle * Mathf.Deg2Rad), Mathf.Sin(fireAngle * Mathf.Deg2Rad), 0) * step;
        if(transform.position.y < -5.5)
        {
            Destroy(this.gameObject);
        }

        if(transform.position.y >= 4.9f && transform.position.y <= 5.1f)
        {
            Instantiate(lavaBurst, transform.position + new Vector3(0, 0.25f, 0), Quaternion.Euler(0, 0, fireAngle));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        col.enabled = false;
        audioSource.Play();
        animator.SetTrigger("MoltenExplosion");
        Destroy(this.gameObject, 0.5f);
    }
}
