using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGroundStartUp : MonoBehaviour {

    public float yStart;
    public float speed;
    public float height;
    float speedDif = 0;
    float period1 = 0;
    float slowFactor = 0;

    public bool offsetPhase = false;

    bool start = false;
    bool hasSet = false;

    SpriteRenderer sr;
    //float height;

    IEnumerator waitTillStart()
    {
        yield return new WaitForSeconds(6f);
        start = true;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        speedDif = slowFactor / 5;
        //height = 98;//sr.sprite.bounds.size.y;
        //print(height);
    }

    void Update()
    {
        Scroll();
        period1 += Time.deltaTime * slowFactor;

        if (SeventhBossScript.bossEnded == false)
        {
            if (SeventhBossIntroDialogue.startBossFight == true)
            {
                if (slowFactor < 1f)
                {
                    slowFactor += Time.deltaTime * .2f;
                }
                else
                {
                    slowFactor = 1f;
                }
            }
        }
        else
        {
            if (hasSet == false)
            {
                hasSet = true;
                StartCoroutine(waitTillStart());
            }

            if (start == true)
            {
                if (slowFactor > 0f)
                {
                    slowFactor -= Time.deltaTime * .2f;
                }
                else
                {
                    slowFactor = 0f;
                }
            }
        }

        
    }

    void Scroll()
    {
        transform.position = Vector3.up * yStart + Vector3.down * ((period1 * speed + (offsetPhase ? height / 2f : 0)) % height);
    }
}
