using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSound : MonoBehaviour {
    AudioSource audioSource;
    public AudioClip enemyDeathSound;
    private bool alreadyPlayed = false;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        if (transform.position.x > -7 && transform.position.x < 8 && transform.position.y > -5 && transform.position.y < 5)
        {
            audioSource.PlayOneShot(enemyDeathSound, 1);
        }
    }

    void Update() {

    }
}
