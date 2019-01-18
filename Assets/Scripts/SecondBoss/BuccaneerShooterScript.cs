using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuccaneerShooterScript : MonoBehaviour {

    float speed = 5;
    static public float angle;
    static public bool charging = false;
    public GameObject buccaneerShot;
    Animator animator;
    AudioSource audioSource;
    bool playShoot = false;
    float period1 = 0;

    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }

    IEnumerator shootBullet()
    {
        shootAnimation();
        yield return new WaitForSeconds(3.3f);
        shoot();
    }

    void shootAnimation()
    {
        animator.SetTrigger("Shoot");
        charging = true;
    }

    void shoot()
    {
        playShoot = true;
        Instantiate(buccaneerShot, transform.position + new Vector3(0, -1.2f, 0), Quaternion.Euler(0,0,angle + 90));
    }

	void Start(){
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}

    void Update()
    {

        if (GameObject.Find("PirateShipBaseBurning(Clone)"))
        {
            transform.position = GameObject.Find("PirateShipBaseBurning(Clone)").transform.position + new Vector3(0, 1.7f, 0);
            if (GameObject.Find("ShipIsDestroyedExplosion(Clone)"))
            {
                StartCoroutine(delayDestroy());
            }
        }
        else
        {
            period1 += Time.deltaTime;
            if(period1 >= 15)
            {
                period1 = 0;
                StartCoroutine(shootBullet());
            }

            transform.position = GameObject.Find("SecondBoss").transform.position + new Vector3(0, 1.7f, 0);
            Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
            angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            if (playShoot == true)
            {
                audioSource.Play();
                playShoot = false;
            }
        }
    }
}
