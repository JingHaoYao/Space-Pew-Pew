using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthBossScript : MonoBehaviour {
    Animator animator;
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    bool hasFlownIn = false;
    float fastStep;
    public Sprite neutral;
    bool movingRight = true;
    float anglePos = Mathf.PI + Mathf.PI / 2;
    float speedBoss = 1;
    bool hasAnimatedFlyIn = false;
    public static int whatTurretFire = 0;
    public static bool fireTurret = false;
    float periodTurretFire = 0;
    public GameObject meteorSpawner, energyTransfer;
    public static bool powerCoreDestroyed = false;
    public static bool bossFireLaser = false;
    bool laserBeam = false;
    float period2 = 35;
    bool hasSet = false;
    bool hasSet2 = false;
    bool hasSet3 = false;
    bool hasSet4 = false;
    bool hasSet5 = false;

    IEnumerator spawnTransfer()
    {
        yield return new WaitForSeconds((10f / 12f) / 0.75f);
        Instantiate(energyTransfer, transform.position, Quaternion.identity);
    }

    void flyToSide()
    {
        if (hasSet == false)
        {
            if (transform.position.x < 18)
            {
                transform.position += Vector3.right * fastStep;
                audioSource.Play();
            }
            else
            {
                hasSet = true;
                audioSource.Pause();
            }
        }
    }

    void flyToMiddle()
    {
        if(transform.position.x < 0.5f)
        {
            if(hasSet4 == false)
            {
                animator.SetTrigger("FlyOut");
                audioSource.Play();
                hasSet4 = true;
            }
                transform.position += Vector3.right * fastStep;
        }
        else
        {
            if(hasSet3 == false)
            {
                StartCoroutine(delayHasFlownIn2());
                hasSet3 = true;
            }
        }
    }

    IEnumerator delayHasFlownOut()
    {
        yield return new WaitForSeconds(0.417f);
        animator.SetTrigger("FlyOut");
        audioSource.Play();
        laserBeam = true;
    }

    IEnumerator delayHasFlownIn()
    {
        yield return new WaitForSeconds(.22f);
        animator.SetTrigger("NeutralMode2");
        audioSource.Pause();
        hasFlownIn = true;
    }

    IEnumerator delayHasFlownIn2()
    {
        animator.SetTrigger("NeutralMode1");
        yield return new WaitForSeconds(.22f);
        animator.SetTrigger("NeutralMode2");
        audioSource.Pause();
        laserBeam = false;
        hasSet = false;
        hasSet2 = false;
        hasSet3 = false;
        anglePos = Mathf.PI + Mathf.PI / 2;
        FourthBossFireLaser.firedLaser = true;
    }

    void Start () {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        transform.position = new Vector3(-45f, 3f, 0);
        meteorSpawner.SetActive(false);
	}

	void Update () {
        if (AliIntroDialogue.startBossFight == true && (BackPowerCore.powerCoreHealth > 0 || FrontPowerCore.powerCoreHealth > 0))
        {
            fastStep = Time.deltaTime * 7;
            if (hasFlownIn == false)
            {
                if (transform.position.x >= 0.5f)
                {
                    meteorSpawner.SetActive(true);
                    if(hasAnimatedFlyIn == false)
                    {
                        StartCoroutine(delayHasFlownIn());
                        animator.SetTrigger("NeutralMode1");
                        hasAnimatedFlyIn = true;
                    }
                }
                else
                {
                    transform.position += Vector3.right * fastStep;
                    audioSource.Play();
                }
            }
            else
            {
                if (laserBeam == false)
                {
                    Vector3 centre = new Vector3(0.5f, 6f, 0);
                    if (!movingRight)
                    {
                        anglePos -= speedBoss * Time.deltaTime;
                        if (anglePos <= Mathf.PI + Mathf.PI / 4)
                        {
                            movingRight = true;
                        }
                    }
                    else
                    {
                        anglePos += speedBoss * Time.deltaTime;
                        if (anglePos >= 2 * Mathf.PI - Mathf.PI / 4)
                        {
                            movingRight = false;
                        }
                    }
                    Vector3 offset = new Vector3(Mathf.Cos(anglePos), Mathf.Sin(anglePos), 0) * 3f;
                    transform.position = centre + offset;
                    speedBoss = 1 / (Mathf.Abs(anglePos - (Mathf.PI * 3 / 2)) + 1);

                    periodTurretFire += Time.deltaTime;

                    if (periodTurretFire >= 1.25f)
                    {
                        periodTurretFire = 0;
                        whatTurretFire = Random.Range(1, 5);
                        fireTurret = true;
                    }
                }
                else
                {
                    flyToSide();
                    if(bossFireLaser == false)
                    {
                        if(hasSet2 == false)
                        {
                            transform.position = new Vector3(-25f, 3f, 0);
                            hasSet2 = true;
                        }
                        if(hasSet3 == false)
                            flyToMiddle();
                    }
                }
            }

            if(powerCoreDestroyed == true)
            {
                period2 += Time.deltaTime;
                if(period2 >= 40f)
                {
                    hasSet4 = false;
                    bossFireLaser = true;
                    period2 = 0;
                    animator.SetTrigger("NeutralToFly");
                    audioSource.Play();
                    StartCoroutine(delayHasFlownOut());
                }
            }
        }
        else if(AliIntroDialogue.startBossFight == true)
        {
            if(hasSet5 == false)
            {
                animator.SetTrigger("BossDestroyed");
                CheckPoints.passedFourthCheckpoint = true;
                Destroy(this.gameObject, 1.917f/0.75f);
                StartCoroutine(spawnTransfer());
                hasSet5 = true;
            }
        }
	}
}
