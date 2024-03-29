﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliOverclock : MonoBehaviour {
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite ali1;
    Sprite[] aliExpressions;
    public GameObject script1;
    GameObject[] aliLines;
    int aliPhase = 0;
    public GameObject fToAdvance;
    bool firstScriptInstant = false;

    void advanceToScreen()
    {
        float step = 10 * Time.deltaTime;
        transform.position += Vector3.left * step;
    }

    void advanceOutScreen()
    {
        float step = 10 * Time.deltaTime;
        transform.position += Vector3.right * step;
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        aliExpressions = new Sprite[] { ali1 };
        aliLines = new GameObject[] { script1 };
        transform.position = new Vector3(11, -1.45f, 0);
        rend.sprite = aliExpressions[aliPhase];
    }

    void Update()
    {
        if (aliPhase < 1)
        {
            if (transform.position.x > 6)
            {
                advanceToScreen();
            }
            else
            {
                if (firstScriptInstant == false)
                {
                    Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                    Instantiate(fToAdvance, new Vector3(0.5f, 1.5f, 0f), Quaternion.identity);
                    firstScriptInstant = true;
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    aliPhase++;
                    audio.Play();
                    Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                    rend.sprite = aliExpressions[aliPhase];
                }
            }
        }
        else
        {
            if (transform.position.x < 11)
                advanceOutScreen();
            else
            {
                ShipSpirit.aliSpoke = true;
                Destroy(this.gameObject);
            }
        }
    }
}
