using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhBossIntroDialogue : MonoBehaviour {
    public GameObject sakamoto;
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite ali1, ali2, ali3, ali4;
    Sprite[] aliExpressions;
    public GameObject script1, script2, script3, script4;
    GameObject[] aliLines;
    int aliPhase = 0;
    bool firstScriptInstant = false;
    public GameObject incomingWarning, fToAdvance;
    public GameObject backGroundMusic;
    public static bool startBossFight = false;

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
        sakamoto.SetActive(false);
        aliExpressions = new Sprite[] { ali1, ali2, ali3, ali4 };
        aliLines = new GameObject[] { script1, script2, script3, script4 };
        transform.position = new Vector3(11, -1.45f, 0);
        rend.sprite = aliExpressions[aliPhase];
    }

    void Update()
    {
        if (aliPhase < 4)
        {
            if (transform.position.x > 6)
            {
                advanceToScreen();
            }
            else
            {
                if (firstScriptInstant == false)
                {
                    rend.sprite = aliExpressions[aliPhase];
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
            if (transform.position.x < 12)
                advanceOutScreen();
            else
            {
                incomingWarning.SetActive(true);
                backGroundMusic.SetActive(true);
                sakamoto.SetActive(true);
                startBossFight = true;
            }
        }
    }
}
