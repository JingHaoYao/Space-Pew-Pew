using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1Script : MonoBehaviour {
    public static float angle = 0;
    float speed = 5;
    public GameObject bullet;
    Animator animator;
    AudioSource audioSource;
    public AudioClip fireSoundEffect;
    bool hasSet = false;
    public GameObject smallExplode;

    IEnumerator dead()
    {
        yield return new WaitForSeconds(0.833f);
        Instantiate(smallExplode, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    IEnumerator fireBullets(int numBullets)
    {
        for(int i = 0; i < numBullets; i++)
        {
            animator.SetTrigger("FireBullet");
            yield return new WaitForSeconds(0.083f);
            Instantiate(bullet, transform.position + new Vector3(0, Mathf.Sin(angle * Mathf.Deg2Rad) * 0.5f, 0), Quaternion.Euler(0, 0, angle + 90));
            audioSource.PlayOneShot(fireSoundEffect);
            yield return new WaitForSeconds(0.2f);
        }
    }

	void Start () {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
	}

	void Update () {
        if(FrontPowerCore.powerCoreHealth > 0 || BackPowerCore.powerCoreHealth > 0)
        {
            transform.position = GameObject.Find("FourthBoss").transform.position + new Vector3(-2.00f, -.1f, 0f);
            Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
            angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

            if (FourthBossScript.fireTurret == true && FourthBossScript.whatTurretFire == 1)
            {
                StartCoroutine(fireBullets(3));
                FourthBossScript.fireTurret = false;
            }
        }
        else
        {
            if(hasSet == false)
            {
                hasSet = true;
                StartCoroutine(dead());
            }
        }
    }
}
