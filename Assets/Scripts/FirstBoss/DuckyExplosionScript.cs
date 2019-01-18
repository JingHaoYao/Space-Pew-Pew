using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckyExplosionScript : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip duckyScream;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, 0.3f);
        if (transform.position.y > -5 && transform.position.y < 5)
        {
            audioSource.PlayOneShot(duckyScream, 1);
        }
    }

    void Update()
    {

    }
}
