using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLightning : MonoBehaviour {
    AudioSource audioSource;

    IEnumerator playAudio()
    {
        yield return new WaitForSeconds(1.083f / 4f);
        audioSource.Play();
    }
    
	void Start () {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(playAudio());
        Destroy(this.gameObject, 1.083f / 2f);
	}

}
