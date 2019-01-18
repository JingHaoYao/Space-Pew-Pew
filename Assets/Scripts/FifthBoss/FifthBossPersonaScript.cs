using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthBossPersonaScript : MonoBehaviour {
    SpriteRenderer rend;
    AudioSource audio;
    int nextSprite = 0;

    void advanceToScreen()
    {
        float step = 10 * Time.deltaTime;
        transform.position -= Vector3.left * step;
    }

    void advanceOutScreen()
    {
        float step = 10 * Time.deltaTime;
        transform.position -= Vector3.right * step;
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        gameObject.SetActive(false);
        transform.position = new Vector3(-11, -1.85f, 0);
    }

    void Update()
    {
        if (nextSprite < 4)
        {
            if (transform.position.x < -6)
            {
                advanceToScreen();
            }
        }
        else
        {
            if (transform.position.x > -13)
            {
                advanceOutScreen();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            nextSprite++;
        }
    }
}
