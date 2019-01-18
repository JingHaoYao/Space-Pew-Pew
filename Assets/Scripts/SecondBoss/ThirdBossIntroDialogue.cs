using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBossIntroDialogue : MonoBehaviour {
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite ali1, ali2;
    Sprite[] aliExpressions;
    public GameObject script1, script2;
    GameObject[] aliLines;
    int aliPhase = 0;
    bool firstScriptInstant = false;
    public GameObject incomingWarning, fToAdvance, thirdBoss, cannon1, cannon2, cannon3, target, buccaneer;
    public GameObject backGroundMusic;

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
        incomingWarning.SetActive(false);
        thirdBoss.SetActive(false);
        cannon1.SetActive(false);
        cannon2.SetActive(false);
        cannon3.SetActive(false);
        target.SetActive(false);
        buccaneer.SetActive(false);
        backGroundMusic.SetActive(false);
        aliExpressions = new Sprite[] { ali1, ali2 };
        aliLines = new GameObject[] { script1, script2 };
        transform.position = new Vector3(11, -1.45f, 0);
        rend.sprite = aliExpressions[aliPhase];
        Instantiate(fToAdvance, new Vector3(0.5f, 1.5f, 0f), Quaternion.identity);
    }

    void Update()
    {
        if (aliPhase < 2)
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
                incomingWarning.SetActive(true);
                thirdBoss.SetActive(true);
                cannon1.SetActive(true);
                cannon2.SetActive(true);
                cannon3.SetActive(true);
                target.SetActive(true);
                buccaneer.SetActive(true);
                backGroundMusic.SetActive(true);
            }
        }
    }
}
