using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBasePlate : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCol;
    AudioSource audioSource;
    public AudioClip hitSoundEffect;
    public Sprite hit0, hit1, hit2, hit3, hit4, hit5, destroyed;
    public GameObject explosion;
    Sprite[] hitSprites;
    public static int numHit = 0;
    public static bool backRepair = false;
    public GameObject repairBot;
    public static bool backPlateBroken = false;
    bool hasSet = false;
    public GameObject smallExplode;

    IEnumerator dead()
    {
        yield return new WaitForSeconds(0.833f);
        Instantiate(smallExplode, transform.position, Quaternion.identity);
        Destroy(this.gameObject, 1.333f/2f);
    }

    IEnumerator SummonRepairBot()
    {
        yield return new WaitForSeconds(10f);
        backRepair = true;
        Instantiate(repairBot, new Vector3(0.5f, 8, 0), Quaternion.identity);
        backRepair = false;
    }

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
        hitSprites = new Sprite[] { hit0, hit1, hit2, hit3, hit4, hit5, destroyed };
	}

	void Update () {
        if (FrontPowerCore.powerCoreHealth > 0 || BackPowerCore.powerCoreHealth > 0)
        {
            spriteRenderer.sprite = hitSprites[numHit];
            transform.position = GameObject.Find("FourthBoss").transform.position + new Vector3(-3.8f, 0, 0);
            if (numHit == 6)
            {
                boxCol.enabled = false;
                backPlateBroken = true;
            }
            else
            {
                boxCol.enabled = true;
                backPlateBroken = false;
            }
        }
        else
        {
            boxCol.enabled = false;
            if (hasSet == false)
            {
                hasSet = true;
                StartCoroutine(dead());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "BlueMeteorite(Clone)" && collision.gameObject.name != "RedMeteorite(Clone)"
           && collision.gameObject.name != "GreenMeteorite(Clone)")
        {
            audioSource.PlayOneShot(hitSoundEffect);
            numHit++;
            if (collision.gameObject.name != "Explosion(Clone)")
            {
                Destroy(collision.gameObject);
                StartCoroutine(HitFrames());
            }

            if (numHit == 6)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                StartCoroutine(SummonRepairBot());
            }
        }
    }
}
