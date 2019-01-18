using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapalmLauncherScript : MonoBehaviour {
    float yDiff = 0.3f;
    bool hasMovedIn = false;
    int[] napalmPositions;
    Animator animator;
    public static float angle = 0;
    public GameObject napalm;
    int napalmCount = 0;
    bool hasSet = false;
    bool hasFired = false;

    bool napalmPlacementAlready(int[] napalmEndPositions0, int index)
    {
        for (int i = index - 1; i >= 0; i--)
        {
            if (napalmEndPositions0[index] == napalmEndPositions0[i])
            {
                return true;
            }
        }
        return false;
    }

    void setNapalmPositions(int[] napalmEndPositions0)
    {
        for (int i = 0; i < 4; i++)
        {
            napalmEndPositions0[i] = 0;
        }

        for (int i = 0; i < 4; i++)
        {
            napalmEndPositions0[i] = Random.Range(1, 16);
            while (napalmPlacementAlready(napalmEndPositions0, i))
            {
                napalmEndPositions0[i] = Random.Range(1, 16);
            }
        }
    }

    IEnumerator launchNapalm()
    {
        animator.SetTrigger("Launch");
        yield return new WaitForSeconds(5f / 12f);
        Instantiate(napalm, transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * 2.4f, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg + 90));
        hasFired = false;
        napalmCount++;
    }


    void Start () {
        animator = GetComponent<Animator>();
        napalmPositions = new int[4] { 0, 0, 0, 0};
	}

    void Update()
    {
        if (LightningCell.cellHealth <= 0)
        {
            if(transform.position.y < 11)
            {
                transform.position += Vector3.up * 12 * Time.deltaTime;
            }
        }
        else
        {
            if (SixthBossScript.numCoresDestroyed < 8)
            {
                transform.position = GameObject.Find("SixthBoss").transform.position + new Vector3(0, 5, 0);
            }
            else
            {
                if (hasMovedIn == false)
                {
                    transform.position += Vector3.down * 5 * Time.deltaTime;
                    if (transform.position.y - GameObject.Find("SixthBoss").transform.position.y < yDiff)
                    {
                        hasMovedIn = true;
                    }
                }
                else
                {
                    if (SixthBossScript.launchNapalm == true)
                    {
                        if (hasSet == false)
                        {
                            setNapalmPositions(napalmPositions);
                            hasSet = true;
                        }

                        Vector3 vectorToTarget = new Vector3(-7.5f + napalmPositions[napalmCount], -4.7f, 0) - transform.position;
                        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x);
                        Quaternion q = Quaternion.AngleAxis((angle * Mathf.Rad2Deg) + 90, Vector3.forward);

                        if (Quaternion.Angle(transform.rotation, q) > 2f)
                        {
                            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 4);
                        }
                        else
                        {
                            if (hasFired == false)
                            {
                                hasFired = true;
                                StartCoroutine(launchNapalm());
                            }
                        }


                        if (napalmCount >= 3)
                        {
                            napalmCount = 0;
                            hasSet = false;
                            hasFired = false;
                            SixthBossScript.launchNapalm = false;
                        }
                    }
                }
            }
        }
    }
}
