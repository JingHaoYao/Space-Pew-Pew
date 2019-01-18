using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliIntroDialogue : MonoBehaviour {
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8;
    Sprite[] aliExpressions;
    public GameObject script1, script2, script3, script4, script5, script6, script7, script8;
    GameObject[] aliLines;
    int aliPhase = 0;
    bool firstScriptInstant = false;
    public static bool startBossFight = false;
    public GameObject incomingWarning, fToAdvance;

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
        aliExpressions = new Sprite[] { ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8 };
        aliLines = new GameObject[] { script1, script2, script3, script4, script5, script6, script7, script8 };
        transform.position = new Vector3(11, -1.45f, 0);
        rend.sprite = aliExpressions[aliPhase];
        Instantiate(fToAdvance, new Vector3(0.5f, 1.5f, 0f), Quaternion.identity);
    }

    void Update()
    {
        if (aliPhase < 8)
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
                startBossFight = true;
                incomingWarning.SetActive(true);
            }
        }
    }
}
