using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGroundStop : MonoBehaviour {

    public float yStart;
    public float speed;
    public float height;
    float speedDif = 0;
    float period1 = 0;
    float slowFactor = 1;

    public bool offsetPhase = false;

    SpriteRenderer sr;
    //float height;

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
        if (slowFactor > 0)
        {
            slowFactor -= speedDif * Time.deltaTime;
        }
        else
        {
            slowFactor = 0;
        }
    }

    void Scroll()
    {
        transform.position = Vector3.up * yStart + Vector3.down * ((period1 * speed + (offsetPhase ? height / 2f : 0)) % height);
    }
}
