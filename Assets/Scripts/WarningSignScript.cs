using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSignScript : MonoBehaviour {
    SpriteRenderer sprite;

    IEnumerator FadeInOut()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2.0f);

        for (float f = 1f; f >= 0; f -= 0.05f)
        {
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

        Destroy(this.gameObject);
    }



    void Start(){
        sprite = GetComponent<SpriteRenderer>();
        Color c = sprite.material.color;
        c.a = 0f;
        sprite.material.color = c;
        StartCoroutine("FadeInOut");
    }
 
	void Update(){
 
    }
}
