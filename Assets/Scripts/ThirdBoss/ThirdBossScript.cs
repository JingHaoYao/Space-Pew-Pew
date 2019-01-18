using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBossScript : MonoBehaviour {
    SpriteRenderer rend;
    BoxCollider2D col;
    float startTime = 0;
    bool setStartTime = false;
    float period = 0f;
    public GameObject lightningPortal;
    public GameObject piercingPortal, spreadPortal, bombPortal, apocalypseLightning;
    public GameObject deadBoss;
    public GameObject bossShield, meteor;
    public GameObject lightningEffectSecondPhase;
    public GameObject ali2;
    public GameObject energyTransfer, spiritTransfer;
    public Sprite whiteShip, blackShip;
    bool shieldDeactivated = false;
    public static int bossHealth = 20;
    public static float angle;
    public static bool shieldOff = false;
    public static bool aliSecondDialogue = false;
    bool transitionedSecondPhase = false;
    int healthThreshold = 10;
    public static int spiritBossHealth = 200;
    public static bool spiritExits = false;
    public static bool backToBlack = false;
    int countToAnni = 0;
    bool anniOccurring;
    public AudioClip rumble, teleportSound, bossHitSound, pierceSound, spreadSound, bombSound;
    bool rumbleOff = false;
    AudioSource audioSource;    

    IEnumerator HitFrames()
    {
        for (int i = 2; i > 0; i--)
        {
            rend.sprite = whiteShip;
            yield return new WaitForSeconds(.1f);
            rend.sprite = blackShip;
            yield return new WaitForSeconds(.1f);
        }
        rend.sprite = blackShip;
    }

    IEnumerator HitFrames2()
    {
        for (int i = 2; i > 0; i--)
        {
            rend.sprite = whiteShip;
            yield return new WaitForSeconds(.1f);
            rend.sprite = blackShip;
            yield return new WaitForSeconds(.1f);
        }
        rend.sprite = whiteShip;
    }

    IEnumerator phaseIn()
    {
        yield return new WaitForSeconds(0.417f);
        rend.enabled = true;
        bossShield.SetActive(true);
    }

    IEnumerator instantiateShot()
    {
        yield return new WaitForSeconds(0.65f);
        int whatShot = Random.Range(0, 3);
        if(whatShot == 1)
        {
            Instantiate(piercingPortal, transform.position, Quaternion.Euler(0, 0, angle + 90));
            audioSource.PlayOneShot(pierceSound);
        }
        else if(whatShot == 2)
        {
            Instantiate(bombPortal, transform.position, Quaternion.Euler(0, 0, angle + 90));
            audioSource.PlayOneShot(bombSound);
        }
        else
        {
            Instantiate(spreadPortal, transform.position, Quaternion.Euler(0, 0, angle + 90));
            audioSource.PlayOneShot(spreadSound);
        }
    }

    IEnumerator teleportPortal()
    {
        Instantiate(lightningPortal, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(teleportSound);
        StartCoroutine(instantiateShot());
        Vector3 newPosition = new Vector3(Random.Range(-6.5f, 7.5f), Random.Range(4f, -1f), 0);
        rend.enabled = false;
        col.enabled = false;
        yield return new WaitForSeconds(0.7f);
        Instantiate(lightningPortal, newPosition, Quaternion.identity);
        audioSource.PlayOneShot(teleportSound);
        transform.position = newPosition;
        yield return new WaitForSeconds(0.458f);
        rend.enabled = true;
        col.enabled = true;
    }

    IEnumerator transitionSecondPhase()
    {
        Instantiate(lightningEffectSecondPhase, transform.position, Quaternion.identity);
        col.enabled = false;
        Instantiate(energyTransfer, transform.position, Quaternion.identity);
        for (int i = 15; i > 0; i--)
        {
            rend.sprite = whiteShip;
            yield return new WaitForSeconds(.1f);
            rend.sprite = blackShip;
            yield return new WaitForSeconds(.1f);
        }
        rend.sprite = blackShip;
        ali2.SetActive(true);
    }


    IEnumerator annihilation()
    {
        Instantiate(apocalypseLightning, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4 / 12f);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(meteor, new Vector3(Random.Range(-5.5f, 6.5f), 10, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        period = 0;
        countToAnni = 0;
        anniOccurring = false;
    }

	void Start () {
        audioSource = GetComponent<AudioSource>();
        rend = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
        rend.enabled = false;
        transform.position = new Vector3(0.5f, 0.5f, 0);
        bossShield.SetActive(false);
        ali2.SetActive(false);
	}

	void Update () {
		if(LightningEffect.endLightningEffect == false)
        {
            transform.position = GameObject.Find("LightningEffect").transform.position;
        }

        if(LightningEffect.startLightningEffect == true)
        {
            audioSource.PlayOneShot(rumble);
            StartCoroutine(phaseIn());
        }

        if(LightningEffect.endLightningEffect == true && rumbleOff == false)
        {
            audioSource.Stop();
            rumbleOff = true;
        }

        if(AliThirdBossScript.startBossFight == true)
        {
            if (bossHealth > 10)
            {
                period += Time.deltaTime;
                if (LightningClash.revealBoss == false)
                {
                    shieldOff = false;
                    if (period > 2)
                    {
                        StartCoroutine(teleportPortal());
                        period = 0;
                    }
                }
                else
                {
                    shieldOff = true;
                }
            }
            else if(aliSecondDialogue == false && bossHealth <= 10)
            {
                if(transitionedSecondPhase == false)
                {
                    StartCoroutine(transitionSecondPhase());
                    transitionedSecondPhase = true;
                }
            }
            else
            {
                if (aliSecondDialogue == true)
                {
                    period += Time.deltaTime;
                    if (LightningClash.revealBoss == false && spiritExits == false)
                    {
                        shieldOff = false;
                        if (period > 1.5f)
                        {
                            if (anniOccurring == false && countToAnni > 10)
                            {
                                anniOccurring = true;
                                StartCoroutine(annihilation());
                            }

                            if (countToAnni <= 10 && anniOccurring == false)
                            {
                                StartCoroutine(teleportPortal());
                                countToAnni++;
                                period = 0;
                            }
                        }
                    }
                    else
                    {
                        shieldOff = true;
                    }

                    if(backToBlack == true)
                    {
                        rend.sprite = blackShip;
                        backToBlack = false;
                    }
                }
            }
        }
        Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        transform.rotation = q;

        if(spiritBossHealth <= 0)
        {
            Instantiate(deadBoss, transform.position, Quaternion.identity);
            EndBossFlash.flashOn = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(bossHitSound);
        if(aliSecondDialogue == true)
        {
            StartCoroutine(HitFrames2());
            Instantiate(spiritTransfer, transform.position, Quaternion.identity);
            Instantiate(energyTransfer, transform.position, Quaternion.identity);
            spiritExits = true;
            col.enabled = false;
        }
        else
        {
            StartCoroutine(HitFrames());
            bossHealth--;
        }
    }
}
