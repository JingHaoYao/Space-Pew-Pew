using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossScript : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    Animator animator;
    public float speedBoss = 5;
    Transform playerFollow;
    public static int bossHealth = 20;
    public static int whichCannon = 0;
    public static bool fireCannon = false;
    public static bool doHitFrames = false;
    bool instantiatedCap = false;
    public GameObject pirateCaptain;
    public GameObject pirateDestroyed;
    float cannonPeriod = 0;

    void selectCannonFire()
    {
        whichCannon = Random.Range(1, 4);
        fireCannon = true;
    }

    void advanceToScreen()
    {
        float step = speedBoss * Time.deltaTime;
        transform.position += Vector3.down * step;
    }

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        transform.position = new Vector3(0.5f, 15, 0);
    }
	
	void Update(){
        float step = speedBoss * Time.deltaTime;
        if(transform.position.y > 2.4f)
        {
            advanceToScreen();
        }
        else
        {
            playerFollow = GameObject.Find("PlayerSpaceShip").transform; 
            if(transform.position.x - playerFollow.position.x > 0.1f)
            {
                transform.position += Vector3.left * step;
            }
            else if(transform.position.x - playerFollow.position.x < -0.1f)
            {
                transform.position += Vector3.right * step;
            }
            else
            {
                transform.position = transform.position;
            }

            if (bossHealth > 0)
            {
                cannonPeriod += Time.deltaTime;
                if(cannonPeriod >= 2)
                {
                    cannonPeriod = 0;
                    selectCannonFire();
                }
            }


        }

        if (doHitFrames)
        {
            StartCoroutine(HitFrames());
            doHitFrames = false;
        }

        if(bossHealth <= 10 && instantiatedCap == false)
        {
            Instantiate(pirateCaptain, GameObject.Find("BuccaneerShooter").transform.position, Quaternion.identity);
            instantiatedCap = true;
        }

        if(bossHealth <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(pirateDestroyed, transform.position, Quaternion.identity);
            GameManager.beatSecondBoss = true;
            GameManager.bossMode = false;
        }
    }

    IEnumerator HitFrames()
    {
        for (int i = 2; i > 0; i--)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(.1f);
        }
        spriteRenderer.enabled = true;
    }
}
