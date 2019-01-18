using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBossFlash : MonoBehaviour {
    SpriteRenderer rend;
    public static bool flashOn = false;
    public GameObject AlI;
    IEnumerator flash()
    {
        Color c = rend.material.color;
        c.a = 1;
        c.b = 1;
        c.g = 1;
        c.a = 0;
        for (float f = 0; f <= 1.05; f += 0.05f)
        {
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(4f);

        for (float f = 1; f >= 0; f -= 0.05f)
        {
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        AlI.SetActive(true);
        DeadThirdBoss.disentegrate = true;
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        c.r = 1f;
        c.b = 1f;
        c.g = 1f;
        rend.material.color = c;
    }

    void Update()
    {
        if (flashOn == true)
        {
            StartCoroutine(flash());
            flashOn = false;
        }
    }
}
