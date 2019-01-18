using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthBossFireLaser : MonoBehaviour {
    Animator animator;
    float speed = 7;
    public GameObject laserBeam;
    float randoAngle = 0;
    bool hasFlownIn = false;
    bool startedCorou = false;
    public static bool firedLaser = false;
    float angle = 0;

    void flyOut()
    {
        float step = speed * Time.deltaTime;
        if (transform.position.y < 30)
        {
            transform.position += Vector3.up * step;
        }
        else
        {
            FourthBossScript.bossFireLaser = false;
            firedLaser = false;
            hasFlownIn = false;
            startedCorou = false;
        }
    }

    IEnumerator fireLaser()
    {
        animator.SetTrigger("Charge1");
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Charge2");
        yield return new WaitForSeconds(3f);
        Instantiate(laserBeam, transform.position + new Vector3(0, -5.8f, 0), Quaternion.Euler(0, 0, randoAngle));
    }

    void flyIn()
    {
        float step = speed * Time.deltaTime;
        if(transform.position.y > 8)
        {
            transform.position += Vector3.down * step;
        }
        else
        {
            hasFlownIn = true;
        }
    }

	void Start () {
        animator = GetComponent<Animator>();
        transform.position = new Vector3(0.5f, 30f, 0);
        randoAngle = Random.Range(260f, 280f);
	}

    void Update()
    {
        Vector3 angleToShip = GameObject.Find("PlayerSpaceShip").transform.position - (transform.position + new Vector3(0f, -5.8f, 0));
        angle = Mathf.Atan2(angleToShip.y, angleToShip.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        if (BackPowerCore.powerCoreHealth > 0 || FrontPowerCore.powerCoreHealth > 0)
        {
            if (FourthBossScript.bossFireLaser == true && firedLaser == false)
            {
                flyIn();
                if (hasFlownIn == true)
                {
                    if (startedCorou == false)
                    {
                        randoAngle = angle;
                        StartCoroutine(fireLaser());
                        startedCorou = true;
                    }
                }
            }
            else
            {
                animator.SetTrigger("Charge1");
                flyOut();
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
