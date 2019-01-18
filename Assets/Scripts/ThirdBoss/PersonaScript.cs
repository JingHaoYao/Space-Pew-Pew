using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaScript : MonoBehaviour {
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite face1, face2, face3, face4, face5, face6, face7, face8;
    public GameObject deathAnimation;
    Sprite[] expressions;
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
        expressions = new Sprite[] { face1, face2, face3, face4, face5, face6, face7, face8 };
        gameObject.SetActive(false);
        transform.position = new Vector3(-11, -1.85f, 0);
    }

    void Update()
    {
        if (nextSprite < 8)
        {
            if (transform.position.x < -6)
            {
                advanceToScreen();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    //audio.Play();
                    nextSprite++;
                    rend.sprite = expressions[nextSprite];
                }
            }
        }
        else
        {
            Instantiate(deathAnimation, transform.position + new Vector3(0, -3.2f, 0), Quaternion.identity);
            ShipDisappearing.fadeAway = true;
            Destroy(this.gameObject);
        }
    }
}
