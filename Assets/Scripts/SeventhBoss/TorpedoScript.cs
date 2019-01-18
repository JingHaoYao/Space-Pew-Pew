using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour {
    AudioSource aud;
    float upSpeed = 25;
    public GameObject explosion;
    bool hasAudioPlayed = false;

	void Start () {
        aud = GetComponent<AudioSource>();
	}

	void Update () {
        transform.position += Vector3.up * upSpeed * Time.deltaTime;
        if(transform.position.y > 6)
        {
            Destroy(this.gameObject);
        }

        if(transform.position.y > -5 && hasAudioPlayed == false)
        {
            hasAudioPlayed = true;
            aud.Play();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
