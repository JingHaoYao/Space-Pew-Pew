using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossScript : MonoBehaviour {
    public float speedBoss = 3;
    private float startTime;
    public float frequencyDuckyThrow = 0.7f;
    public GameObject duckyProjectile, blueDucky, greenDucky, redDucky, laserStar, FirstBossExploding;
    GameObject[] duckyList;
    SpriteRenderer spriteRenderer;
    BoxCollider2D hitbox;
    AudioSource audioSource;
    public AudioClip bossHitSound;
    bool isMovingRight = true;
    Animator animator;
    public static int bossHealth = 20;
    int throwDirection = 0;
    public static bool launchingLaser = false;
    public static float angleLaserStar;
    float period = 0;
    float period2 = 0;

    void advanceToScreen()
    {
        float step = speedBoss * Time.deltaTime;
        transform.position += Vector3.down * step;
    }

    IEnumerator ThrowDucky()
    {
        if (launchingLaser == false)
        {
            throwDirection = Random.Range(0, 2);
            if (throwDirection == 0)
            {
                animator.SetTrigger("ThrowProjectileLeft");
            }
            else
            {
                animator.SetTrigger("ThrowProjectileRight");
            }

            yield return new WaitForSeconds(0.4f);

            if (throwDirection == 0)
            {
                Instantiate(duckyList[Random.Range(0, 6)], transform.position + new Vector3(-2f, -1f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(duckyList[Random.Range(0, 6)], transform.position + new Vector3(2f, -1f, 0), Quaternion.identity);
            }
        }
    }
    

	void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        duckyList = new GameObject[] { duckyProjectile, duckyProjectile, duckyProjectile,
                                       blueDucky, greenDucky, redDucky };
        transform.position = new Vector3(0.5f, 15, 0);
        startTime = Time.time;
        InvokeRepeating("shootLaser", 9f, 10f);
        InvokeRepeating("shootLaser", 9.3f, 10f);
        InvokeRepeating("shootLaser", 9.6f, 10f);
        InvokeRepeating("shootLaser", 9.9f, 10f);
        InvokeRepeating("shootLaser", 10.2f, 10f);
    }

    void Update() {
        float step = speedBoss * Time.deltaTime;
        period += Time.deltaTime;
        period2 += Time.deltaTime;

        if (transform.position.y > 4)
        {
            advanceToScreen();
        }
        else
        {
            if (isMovingRight)
            {
                transform.position += Vector3.right * step;
                if(transform.position.x >= 4)
                {
                    
                    isMovingRight = false;
                }
            }
            else
            {
                transform.position += Vector3.left * step;
                if(transform.position.x <= -3)
                {
                    isMovingRight = true;
                }
            }
        }

        if(bossHealth <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(FirstBossExploding, transform.position, Quaternion.identity);
            GameManager.beatFirstBoss = true;
            CheckPoints.passedFirstCheckpoint = true;
            GameManager.bossMode = false;
        }

        if(period2 >= 7f)
        {
            if (period >= frequencyDuckyThrow)
            {
                period = 0;
                StartCoroutine(ThrowDucky());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name != "BasicRedEnemy(Clone)" && collision.gameObject.name != "BasicBlueEnemy(Clone)" 
            && collision.gameObject.name != "BasicGreenEnemy(Clone)" && collision.gameObject.name != "DuckyProjectile(Clone)"
            && collision.gameObject.name != "BlueDuckyProjectile(Clone)" && collision.gameObject.name != "GreenDuckyProjectile(Clone)" 
            && collision.gameObject.name != "RedDuckyProjectile(Clone)" && collision.gameObject.name != "LaserStar(Clone)"
            && collision.gameObject.name != "FirstBossShield")
        {
            audioSource.PlayOneShot(bossHitSound, 1);
            StartCoroutine(HitFrames());
            if (collision.gameObject.name != "PiercingShot(Clone)" || collision.gameObject.name != "Explosion(Clone)" 
                || collision.gameObject.name != "DuckyExplosion(Clone)")
            {
                Destroy(collision.gameObject);
            }
            bossHealth--;
            Debug.Log(bossHealth);
        }
    }

    public IEnumerator HitFrames()
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

    void shootLaser()
    {
        angleLaserStar = 225f;
        float startTime = Time.time;
        launchingLaser = true;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(laserStar, transform.position + new Vector3(0, -1.2f, 0), Quaternion.identity);
            angleLaserStar += 30f;
        }
        launchingLaser = false;
    }
}
