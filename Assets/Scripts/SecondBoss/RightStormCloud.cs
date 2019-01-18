using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightStormCloud : MonoBehaviour {
    static public bool advanceIn = false;
    SpriteRenderer rend;
    float speed = 0.5f;

    IEnumerator FadeInOut()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        RightLightningStorm.lightningAway = true;
    }

    void advanceToScreen()
    {
        float step = speed * Time.deltaTime;
        transform.position += new Vector3(1, 0, 0) * step;
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0;
        rend.material.color = c;
        transform.position = new Vector3(6.8f, 0, 0);
    }

    void Update()
    {
        if (advanceIn == true)
        {
            StartCoroutine(FadeInOut());
            advanceIn = false;
        }
    }
}
