using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormLightningFlash : MonoBehaviour {
    SpriteRenderer rend;
    public static bool lightningEffect = false;
    public static bool dontFire = false;
    IEnumerator LightningFlash()
    {
        yield return new WaitForSeconds(5f);
        dontFire = true;
        Color c = rend.material.color;
        c.a = 0;
        c.b = 0;
        c.g = 0;
        c.a = 0;
        for (float f = 0; f <= 1.05; f += 0.05f)
        {
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(0.1f);
        LightningStrike.lightningFlashOn = true;
        yield return new WaitForSeconds(0.1f);
        LightningStrike.lightningFlashOn = false;
        for (float f = 1; f >= 0; f -= 0.025f)
        {
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        dontFire = false;
    }

    void Start(){
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        c.r = 0f;
        c.b = 0f;
        c.g = 0f;
        rend.material.color = c;
    }
	
	void Update(){
        if(lightningEffect == true)
        {
            StartCoroutine(LightningFlash());
            lightningEffect = false;
        }
    }
}
