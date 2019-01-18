using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossScript : MonoBehaviour
{
    float speed = 30;
    float period1 = 0;
    float slowFactor = 1;
    public float yStart;
    public static bool bossFightStarted = false;
    public static int numCoresDestroyed = 0;
    public static int whichBall = 0;
    public static int whichLauncher = 0;
    public static int rocketNumber = 0;
    public static bool launchNapalm = false;

    public GameObject lightningCell;
    Animator animator;
    AudioSource aud;

    float period2 = 4;
    float period3 = 0;
    float period4 = 0;
    bool hasArrived = false;
    bool hasSet1 = false;
    bool hasSet2 = false;

    IEnumerator bossDefeated()
    {
        CheckPoints.passedSixthCheckPoint = true;
        yield return new WaitForSeconds(1.417f);
        SixthBossFadeInOut.fadeOut = true;
    }

    void Start()
    {
        lightningCell.SetActive(false);
        animator = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (LightningCell.cellHealth <= 0)
        {
            if(hasSet2 == false)
            {
                aud.Play();
                animator.SetTrigger("Defeated");
                StartCoroutine(bossDefeated());
                hasSet2 = true;
            }
        }
        else
        {

            if (hasArrived == false)
            {
                if (slowFactor > 0)
                {
                    slowFactor -= 0.2f * Time.deltaTime;
                }
                else
                {
                    slowFactor = 0;
                    hasArrived = true;
                }
                period1 += Time.deltaTime * slowFactor;
                transform.position = Vector3.up * yStart + Vector3.down * period1 * speed;
            }
            else
            {
                if (bossFightStarted == true)
                {
                    period2 += Time.deltaTime;
                    period3 += Time.deltaTime;

                    if (period2 >= 10f)
                    {
                        if (numCoresDestroyed < 8)
                        {
                            period2 = 0;
                            whichBall = Random.Range(1, 3);
                        }
                    }

                    if (period3 >= 4f)
                    {
                        period3 = 0;
                        whichLauncher = Random.Range(1, 3);
                        rocketNumber = whichLauncher;
                    }

                    if (numCoresDestroyed >= 8)
                    {
                        lightningCell.SetActive(true);
                        period4 += Time.deltaTime;
                        if (period4 >= 6)
                        {
                            launchNapalm = true;
                            period4 = 0;
                        }
                    }
                }
            }
        }
    }
}
