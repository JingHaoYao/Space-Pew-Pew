using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public static bool shakeCam = false;
    public static bool spiritHit = false;
    Vector3 origPosition;
    AudioSource audioSource;


    IEnumerator shakeCamera(float duration, float magnitude)
    {
        yield return new WaitForSeconds(4.5f);
        float elapsed = 0.0f;
        LightningEffect.startLightningEffect = true;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, origPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = origPosition;
        LightningEffect.endLightningEffect = true;
    }

    IEnumerator shakeCam2(float duration, float magnitude)
    {
        float elapsed = 0.0f;
        audioSource.Play();
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, origPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = origPosition;
        audioSource.Stop();
    }

	void Start()
    {
        audioSource = GetComponent<AudioSource>();
        origPosition = transform.localPosition;
        StartCoroutine(shakeCamera(7.5f,0.1f));
	}

	void Update()
    {
		if(shakeCam == true)
        {
            StartCoroutine(shakeCam2(2f, 0.2f));
            shakeCam = false;
        }

        if(spiritHit == true)
        {
            StartCoroutine(shakeCam2(0.1f, 0.2f));
            spiritHit = false;
        }

	}
}
