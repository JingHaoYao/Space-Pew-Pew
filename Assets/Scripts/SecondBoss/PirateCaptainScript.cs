using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateCaptainScript : MonoBehaviour {
    float secondBossXPosition = 0;
    float yPosition = 4.1f;
    bool hasAnimated = false;
    public static float angleDart = 0;
    Animator animator;
    AudioSource audioSource;
    bool playElec = false;
    public GameObject waterDart,redFish,blueFish,greenFish;
    GameObject[] projectileList;

    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }

    IEnumerator captainStuff()
    {
        animator.SetTrigger("DrawSword");
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("LightningEffect");
        WaterStorm.rotateIn = true;
        yield return new WaitForSeconds(1f);
        playElec = true;
        LeftStormCloud.advanceIn = true;
        RightStormCloud.advanceIn = true;
    }

    IEnumerator shootWaterDarts()
    {
        for(int i = 0; i < 7; i++)
        {
            angleDart = 225 + 15 * i;
            Instantiate(projectileList[Random.Range(0, 14)], GameObject.Find("WaterStorm").transform.position, Quaternion.Euler(0,0,angleDart + 90));
            yield return new WaitForSeconds(0.5f);
            Instantiate(projectileList[Random.Range(0, 14)], GameObject.Find("WaterStorm").transform.position, Quaternion.Euler(0, 0, angleDart + 90));
            yield return new WaitForSeconds(0.2f);
        }
    }

    void startShootingDarts()
    {
        StartCoroutine(shootWaterDarts());
    }

    void startLightningEffect()
    {
        StormLightningFlash.lightningEffect = true;
    }

    void advanceToFront()
    {
        float step = 2 * Time.deltaTime;
        yPosition -= 1 * step;
    }

	void Start(){
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("startShootingDarts", 5f, 12f);
        InvokeRepeating("startLightningEffect", 1.1f, 20f);
        projectileList = new GameObject[] { waterDart, waterDart, waterDart, waterDart, waterDart, waterDart, waterDart,
                                            waterDart, waterDart, waterDart, waterDart, greenFish, redFish, blueFish };
	}
	
	void Update(){
        if (GameObject.Find("PirateShipBaseBurning(Clone)"))
        {
            secondBossXPosition = GameObject.Find("PirateShipBaseBurning(Clone)").transform.position.x;
            transform.position = new Vector3(secondBossXPosition, yPosition, 0);
            if (GameObject.Find("ShipIsDestroyedExplosion(Clone)"))
            {
                StartCoroutine(delayDestroy());
            }
        }
        else
        {
            secondBossXPosition = GameObject.Find("SecondBoss").transform.position.x;
            transform.position = new Vector3(secondBossXPosition, yPosition, 0);
            if (transform.position.y > 0.15)
            {
                advanceToFront();
            }
            else
            {
                if (hasAnimated == false)
                {
                    StartCoroutine(captainStuff());
                    hasAnimated = true;
                }
            }

            if (playElec == true)
            {
                audioSource.Play();
                playElec = false;
            }
        }
    }
}
