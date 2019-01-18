using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliCutSceneScript : MonoBehaviour {
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10, ali11, ali12, ali13, ali14, ali15,
                  ali16, ali17, ali18, ali19, ali20, ali21, ali22, ali23;
    Sprite[] aliExpressions;
    public GameObject script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12,
                      script13, script14, script15, script16, script17, script18, script19, script20, script21, script22, script23;
    GameObject[] aliLines;

    GameObject[] backGrounds;
    public GameObject back1, back2, back3, back4, back5, back6, back7, back8, back9, back10, back11;
    int aliPhase = 0;

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
        aliExpressions = new Sprite[] { ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10, ali11, ali12, ali13, ali14, ali15,
                                        ali16, ali17, ali18, ali19, ali20, ali21, ali22, ali23 };
        aliLines = new GameObject[] { script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12,
                                      script13, script14, script15, script16, script17, script18, script19, script20, script21, script22, script23 };
        backGrounds = new GameObject[] { back1, back2, back3, back4, back5, back6, back7, back8, back9, back10, back11 };
        transform.position = new Vector3(11, -1.45f, 0);
        rend.sprite = aliExpressions[aliPhase];
    }

    void Update()
    {
        if (aliPhase < 23)
        {
            if (transform.position.x > 6)
            {
                advanceToScreen();
            }
            else
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    aliPhase++;
                    audio.Play();
                    rend.sprite = aliExpressions[aliPhase];

                    if(aliPhase >= 6 && aliPhase <= 16)
                    {
                        if(aliPhase != 9 && aliPhase != 16)
                        {
                            Instantiate(backGrounds[aliPhase - 6], new Vector3(0, 0, 0), Quaternion.identity);
                        }
                    }

                    if(aliPhase >= 12 && aliPhase <= 14)
                    {
                        Instantiate(aliLines[aliPhase], new Vector3(0.5f, -3f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                    }
                }
            }
        }
        else
        {
            if (transform.position.x < 11)
                advanceOutScreen();
            else
            {
                FadeInOutCutScene.fadeOut = true;
            }
        }
    }
}
