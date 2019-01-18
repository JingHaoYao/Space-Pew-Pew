using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossIntroDialogue : MonoBehaviour {
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite ali1, ali2, ali3;
    Sprite[] aliExpressions;
    public GameObject script1, script2, script3;
    GameObject[] aliLines;
    int aliPhase = 0;
    public GameObject incomingWarning, fToAdvance;
    public GameObject backGroundMusic;
    bool firstScriptInstance = false;

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
        backGroundMusic.SetActive(false);
        aliExpressions = new Sprite[] { ali1, ali2, ali3 };
        aliLines = new GameObject[] { script1, script2, script3 };
        transform.position = new Vector3(11, -1.45f, 0);
        rend.sprite = aliExpressions[aliPhase];
    }

    void Update()
    {
        if (GameObject.Find("SixthBoss").transform.position.y < 1.5f)
        {
            if (aliPhase < 3)
            {
                if (transform.position.x > 6)
                {
                    advanceToScreen();
                }
                else
                {
                    if (firstScriptInstance == false)
                    {
                        Instantiate(fToAdvance, new Vector3(0.5f, 1.5f, 0f), Quaternion.identity);
                        Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                        firstScriptInstance = true;
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
                    backGroundMusic.SetActive(true);
                    SixthBossScript.bossFightStarted = true;
                }
            }
        }
    }
}
