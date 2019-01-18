using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkHoleScript : MonoBehaviour {
    AudioSource audioSource;
    public AudioClip blackHoleSound;

	void Start(){
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, 0.3f);
        if (transform.position.y > -5 && transform.position.y < 5)
        {
            audioSource.PlayOneShot(blackHoleSound, 1);
        }
    }
	
	void Update(){
		
	}
}
