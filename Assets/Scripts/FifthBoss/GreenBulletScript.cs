using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBulletScript : MonoBehaviour {
    float speed = 10;
    float step = 0;
    public GameObject explosion;

    void Start()
    {

    }

    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position += Vector3.down * step;
        if (transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerMovement.pierceCount + PlayerMovement.spreadCount + PlayerMovement.bombCount < 9)
        {
            PlayerMovement.spreadCount++;
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
