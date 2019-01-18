using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {
    public GameObject incomingWarning;
    AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
            audioSource.Play();
	}
}
