using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStorm : MonoBehaviour {
    public static bool rotateIn = false;
    SpriteRenderer rend;
    Animator animator;
    AudioSource audioSource;
    public static bool playStorm;
    
    IEnumerator animationStart()
    {
        animator.SetTrigger("LoadIn");
        rend.enabled = true;
        yield return new WaitForSeconds(0.4f);
        animator.SetTrigger("Rotation");
    }

    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }

    void Start(){
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        rend.enabled = false;
	}
	
	void Update(){
        if (GameObject.Find("PirateShipBaseBurning(Clone)"))
        {
            transform.position = GameObject.Find("PirateShipBaseBurning(Clone)").transform.position + new Vector3(0, 0.6f, 0);
            if (GameObject.Find("ShipIsDestroyedExplosion(Clone)"))
            {
                StartCoroutine(delayDestroy());
            }
        }
        else
        {
            transform.position = GameObject.Find("SecondBoss").transform.position + new Vector3(0, 0.6f, 0);
            if (rotateIn == true)
            {
                StartCoroutine(animationStart());
                rotateIn = false;
            }

            if (playStorm == true)
            {
                audioSource.Play();
                playStorm = false;
            }
        }
	}
}
