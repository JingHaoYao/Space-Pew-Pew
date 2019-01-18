using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateCannon2 : MonoBehaviour
{
    SpriteRenderer rend;
    Animator animator;
    AudioSource audioSource;
    public GameObject cannonShell;
    public GameObject cannonIsHitExplosion;
    public GameObject cannonIsDestroyedExplosion;
    public GameObject shipCrack;
    public Sprite defaultCannon;
    public GameObject blueKeg, greenKeg, redKeg;
    GameObject[] kegList;
    BoxCollider2D hitBox;
    bool isHit = false;
    bool playCannon = false;
    public float waitTime = 6f;

    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }

    IEnumerator isDeadRespawn()
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < 4; i++)
        {
            rend.enabled = true;
            yield return new WaitForSeconds(0.1f);
            rend.enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
        rend.enabled = true;
        isHit = false;
        rend.sprite = defaultCannon;
    }

    IEnumerator spawnDestroyedExplosion()
    {
        yield return new WaitForSeconds(0.417f);
        Instantiate(cannonIsDestroyedExplosion, transform.position, Quaternion.identity);
        Instantiate(shipCrack, transform.position + new Vector3(0,0.25f,0), Quaternion.identity);
        rend.enabled = false;
        StartCoroutine(isDeadRespawn());
        SecondBossScript.bossHealth--;
        SecondBossScript.doHitFrames = true;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(kegList[Random.Range(0, 3)], transform.position, Quaternion.identity);
        }
    }

    IEnumerator fireCannonShot()
    {
        hitBox.enabled = true;
        yield return new WaitForSeconds(1f);
        if (isHit == false)
        {
            playCannon = true;
            Instantiate(cannonShell, transform.position + new Vector3(0, -0.6f, 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(0.4f);
        hitBox.enabled = false;
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hitBox = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        hitBox.enabled = false;
        kegList = new GameObject[] { blueKeg, redKeg, greenKeg };
    }

    void Update()
    {
        if (GameObject.Find("PirateShipBaseBurning(Clone)"))
        {
            transform.position = GameObject.Find("PirateShipBaseBurning(Clone)").transform.position + new Vector3(1.4f, -0.1f, 0);
            if (GameObject.Find("ShipIsDestroyedExplosion(Clone)"))
            {
                StartCoroutine(delayDestroy());
            }
        }
        else
        {
            transform.position = GameObject.Find("SecondBoss").transform.position + new Vector3(1.4f, -0.1f, 0);

            if (isHit == false)
            {
                if (SecondBossScript.fireCannon == true)
                {
                    if (SecondBossScript.whichCannon == 2)
                    {
                        if (StormLightningFlash.dontFire == false)
                        {
                            animator.SetTrigger("FireCannon");
                            StartCoroutine(fireCannonShot());
                        }
                        SecondBossScript.fireCannon = false;
                    }
                }
            }

            if (playCannon == true)
            {
                audioSource.Play();
                playCannon = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "BuccaneerShot(Clone)" && collision.gameObject.name != "CannonShot(Clone)")
        {
            isHit = true;
            animator.SetTrigger("CannonIsHit");
            StartCoroutine(spawnDestroyedExplosion());
            Instantiate(cannonIsHitExplosion, collision.gameObject.transform.position, Quaternion.identity);
            hitBox.enabled = false;
        }
    }
}