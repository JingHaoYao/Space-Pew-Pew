using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidObstacleScript : MonoBehaviour {
    AudioSource aud;
    BoxCollider2D boxCol;
    Animator animator;
    public float speed = 5;
    public GameObject redDrop, greenDrop, blueDrop;
    GameObject[] dropList;

    IEnumerator spawnDrops()
    {
        yield return new WaitForSeconds(0.4f);
        for(int i = 0; i < 3; i++)
        {
            if (transform.position.x < 0)
            {
                Instantiate(dropList[Random.Range(0, 3)], transform.position - new Vector3(3f , 0, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(dropList[Random.Range(0, 3)], transform.position + new Vector3(3f, 0, 0), Quaternion.identity);
            }
        }
    }

	void Start () {
        boxCol = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        dropList = new GameObject[] { redDrop, greenDrop, blueDrop };
	}
	
	void Update () {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aud.Play();
        boxCol.enabled = false;
        animator.SetTrigger("Break");
        StartCoroutine(spawnDrops());
        Destroy(this.gameObject, 0.5f);
    }
}
