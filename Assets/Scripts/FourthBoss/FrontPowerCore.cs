using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontPowerCore : MonoBehaviour {
    BoxCollider2D boxCol;
    AudioSource audioSource;
    public static int powerCoreHealth = 5;
    public GameObject explosion;
    SpriteRenderer spriteRenderer;

    IEnumerator HitFrames()
    {
        for (int i = 2; i > 0; i--)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(.05f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(.05f);
        }
        spriteRenderer.enabled = true;
    }

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
	}

	void Update () {
        transform.position = GameObject.Find("FrontBasePlate").transform.position;

        if(FrontBasePlate.frontPlateBroken == true)
        {
            boxCol.enabled = true;
        }
        else
        {
            boxCol.enabled = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(HitFrames());
        powerCoreHealth--;
        audioSource.Play();
        if(powerCoreHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            FourthBossScript.powerCoreDestroyed = true;
        }
    }
}
