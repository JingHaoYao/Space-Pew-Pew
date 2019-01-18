using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthBoss : MonoBehaviour {
    Animator animator;
    BoxCollider2D boxCol1;
    CircleCollider2D circCol;
    SpriteRenderer rend;
    AudioSource aud;
    bool hasFlownIn = false;
    float step = 0;
    public GameObject lineEnds;
    public static float laserLineDuration = 4f;
    int[] laserEndPositions;
    int[] bulletPlacementPositions;
    int[] sidePortalPositions;
    int[] bombPositions;
    public GameObject whiteBullet, redBullet, greenBullet, blueBullet;
    public GameObject bulletPortal;
    public GameObject sideBulletPortal;
    public GameObject bombPortal;
    public GameObject switchPortal;
    public GameObject bossDefeated;
    GameObject[] bulletList;
    int numLaserEnds = 3;
    int numBullets = 4;
    float period1 = 6;
    float period2 = 13;
    public static bool comingLeft = true;
    bool movingRight = false;
    float anglePos = Mathf.PI + Mathf.PI / 2;
    float speedBoss = 0;
    bool hasAnimatedIn = false;
    Vector3 centre = new Vector3(0.5f, 7f, 0);
    int bossHealth = 30;
    float threshold = 8;
    int numSidePortals = 3;
    int numBombPortals = 8;

    bool bulletPlacementAlready(int[] laserEndPositions0, int[] bulletPlacementPositions0, int index)
    {
        for (int i = index - 1; i >= 0; i--)
        {
            if (bulletPlacementPositions0[index] == bulletPlacementPositions0[i])
            {
                return true;
            }
        }

        for(int i = 0; i < 5; i++)
        {
            if (bulletPlacementPositions0[index] == laserEndPositions0[i])
            {
                return true;
            }
        }
        return false;
    }

    void setBulletPositions(int[] bulletPlacementPositions0, int[] laserEndPositions0)
    {
        for (int i = 0; i < 4; i++)
        {
            bulletPlacementPositions0[i] = 0;
        }

        for (int k = 0; k < 4; k++)
        {
            bulletPlacementPositions0[k] = Random.Range(1, 16);
            while (bulletPlacementAlready(laserEndPositions0, bulletPlacementPositions0, k))
            {
                bulletPlacementPositions0[k] = Random.Range(1, 16);
            }
        }
    }

    bool laserPlacementAlready(int[] laserEndPositions0, int index)
    {
        for (int i = index - 1; i >= 0; i--)
        {
            if(laserEndPositions0[index] == laserEndPositions0[i])
            {
                return true;
            }
        }
        return false;
    }

    void setLaserPositions(int[] laserEndPositions0)
    {
        for(int i = 0; i < 5; i++)
        {
            laserEndPositions0[i] = 0;
        }

        for(int i = 0; i < 5; i++)
        {
            laserEndPositions0[i] = Random.Range(1, 16);
            while(laserPlacementAlready(laserEndPositions0, i))
            {
                laserEndPositions0[i] = Random.Range(1, 16);
            }
        }
    }

    void setSidePositions(int[] laserEndPositions0)
    {
        for (int i = 0; i < 5; i++)
        {
            laserEndPositions0[i] = 0;
        }

        for (int i = 0; i < 5; i++)
        {
            laserEndPositions0[i] = Random.Range(1, 6);
            while (laserPlacementAlready(laserEndPositions0, i))
            {
                laserEndPositions0[i] = Random.Range(1, 6);
            }
        }
    }

    void setBombPositions(int[] bombPositions0)
    {
        for (int i = 0; i < 10; i++)
        {
            bombPositions0[i] = 0;
        }

        for (int i = 0; i < 10; i++)
        {
            bombPositions0[i] = Random.Range(1, 16);
            while (laserPlacementAlready(bombPositions0, i))
            {
                bombPositions0[i] = Random.Range(1, 16);
            }
        }
    }

    IEnumerator displayLightning()
    {
        animator.SetTrigger("Neutral2");
        yield return new WaitForSeconds(4);
        animator.SetTrigger("Neutral1");
        hasAnimatedIn = true;
    }


    IEnumerator phaseInToNeutral()
    {
        animator.SetTrigger("PhaseIn");
        yield return new WaitForSeconds(1.5f);
        animator.SetTrigger("Neutral1");
        yield return new WaitForSeconds(1f);
        StartCoroutine(displayLightning());
    }

    IEnumerator spawnStraightLine(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(bulletList[Random.Range(0, 6)], new Vector3(-7.5f + bulletPlacementPositions[index] * 1f, 4f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
        }
    }

    IEnumerator spawnBullets()
    {
        yield return new WaitForSeconds(0.5f);
        for (int k = 0; k < numBullets; k++)
        {
            Instantiate(bulletPortal, new Vector3(-7.5f + bulletPlacementPositions[k] * 1f, 4f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.417f);
            StartCoroutine(spawnStraightLine(k));
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator spawnBombs()
    {
        StartCoroutine(handUp());
        yield return new WaitForSeconds(1.583f / 3f);
        setBombPositions(bombPositions);
        for(int k = 0; k < numBombPortals; k++)
        {
            Instantiate(bombPortal, new Vector3(-7.5f + bombPositions[k] * 1f, 4f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator spawnSidePortals()
    {
        setSidePositions(sidePortalPositions);
        int whichSide = Random.Range(1, 3);
        if(whichSide == 1)
        {
            comingLeft = true;
            StartCoroutine(sideHandAnim());
            yield return new WaitForSeconds(0.4f);
            for (int k = 0; k < numSidePortals; k++)
            {
                Instantiate(sideBulletPortal, new Vector3(-6.5f, -1 + sidePortalPositions[k] * 1f, 0), Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
            }
        }
        else
        {
            comingLeft = false;
            StartCoroutine(sideHandAnim());
            yield return new WaitForSeconds(0.4f);
            for (int k = 0; k < numSidePortals; k++)
            {
                Instantiate(sideBulletPortal, new Vector3(7.5f, -1 + sidePortalPositions[k] * 1f, 0), Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    IEnumerator sideHandAnim()
    {
        if(comingLeft == true)
        {
            animator.SetTrigger("LeftHand");
            yield return new WaitForSeconds(0.917f);
            animator.SetTrigger("Neutral1");
        }
        else
        {
            animator.SetTrigger("RightHand");
            yield return new WaitForSeconds(0.917f);
            animator.SetTrigger("Neutral1");
        }
    }

    IEnumerator hitFrames()
    {
        for(int i = 0; i < 2; i++)
        {
            rend.enabled = false;
            yield return new WaitForSeconds(0.05f);
            rend.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator handUp()
    {
        animator.SetTrigger("HandUp");
        yield return new WaitForSeconds(1.583f / 1.5f);
        animator.SetTrigger("Neutral1");
    }

    IEnumerator spawnStraightBullets()
    {
        StartCoroutine(handUp());
        yield return new WaitForSeconds(1.583f / 3f);
        setLaserPositions(laserEndPositions);
        setBulletPositions(bulletPlacementPositions, laserEndPositions);
        StartCoroutine(spawnBullets());
        for (int i = 0; i < numLaserEnds; i++)
        {
            Instantiate(lineEnds, new Vector3(-7.5f + laserEndPositions[i] * 1f, 6f, 0), Quaternion.Euler(0, 0, 180));
        }
    }

	void Start () {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        boxCol1 = GetComponent<BoxCollider2D>();
        circCol = GetComponent<CircleCollider2D>();
        aud = GetComponent<AudioSource>();
        boxCol1.enabled = false;
        circCol.enabled = false;
        transform.position = new Vector3(0.5f, 36f, 0f);
        laserEndPositions = new int[5] { 0, 0, 0, 0, 0};
        bulletPlacementPositions = new int[4] { 0, 0, 0, 0 };
        sidePortalPositions = new int[5] { 0, 0, 0, 0, 0 };
        bombPositions = new int[10] { 0,0,0,0,0,0,0,0,0,0 };
        bulletList = new GameObject[6] { whiteBullet, whiteBullet, whiteBullet, redBullet, greenBullet, blueBullet };
	}

	void Update () {
        step = 10 * Time.deltaTime;
        if(hasFlownIn == false)
        {
            if(transform.position.y > 1)
            {
                transform.position += Vector3.down * step;
            }
            else
            {
                StartCoroutine(phaseInToNeutral());
                hasFlownIn = true;
            }
        }
        else if(hasAnimatedIn == true)
        {
            boxCol1.enabled = true;
            circCol.enabled = true;
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
            Vector3 offset = new Vector3(Mathf.Cos(anglePos), Mathf.Sin(anglePos), 0) * 6f;
            transform.position = centre + offset;
            speedBoss = 0.1f + Mathf.Abs(Mathf.Sin(anglePos))/2;

            period1 += Time.deltaTime;
            if(period1 >= threshold)
            {
                int whichAttack = Random.Range(1, 4);
                if(whichAttack == 1)
                {
                    StartCoroutine(spawnStraightBullets());
                }
                else if(whichAttack == 2)
                {
                    StartCoroutine(spawnSidePortals());
                }
                else
                {
                    StartCoroutine(spawnBombs());
                }
                period1 = 0;
            }
        }

        if(bossHealth < 16)
        {
            numLaserEnds = 5;
            threshold = 6.5f;
            numBombPortals = 10;
            numSidePortals = 5;
            period2 += Time.deltaTime;
            if(period2 > 15)
            {
                period2 = 0;
                Instantiate(switchPortal, new Vector3(0.5f, 2f, 0), Quaternion.identity);
            }
        }

        if(bossHealth <= 0)
        {
            Destroy(this.gameObject);
            CheckPoints.passedFifthCheckPoint = true;
            Instantiate(bossDefeated, transform.position, Quaternion.identity);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aud.Play();
        bossHealth--;
        StartCoroutine(hitFrames());
        Debug.Log(bossHealth);
    }
}
