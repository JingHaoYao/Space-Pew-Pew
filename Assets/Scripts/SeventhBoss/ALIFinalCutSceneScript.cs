using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALIFinalCutSceneScript : MonoBehaviour {
    AudioSource audio;
    public Sprite ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10, ali11, ali12, ali13, ali14, ali15, ali16, ali17, ali18, ali19, ali20, ali21,
           ali22, ali23, ali24, ali25, ali26, ali27, ali28;
    Sprite[] aliExpressions;
    public GameObject script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12,
                      script13, script14, script15, script16, script17, script18, script19, script20, script21, script22, script23,
                      script24, script25, script26, script27, script28;
    GameObject[] aliLines;
    GameObject[] backGrounds;
    public GameObject back1, back2, back3, back4, back5, back6, back7, back8, back9, back10;
    int aliPhase = 0;
    int backGroundPhase = 0;
    bool firstScriptInstance = false;
    public GameObject fToAdvance;
    SpriteRenderer rend;

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
        aliLines = new GameObject[] { script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12,
                      script13, script14, script15, script16, script17, script18, script19, script20, script21, script22, script23,
                      script24, script25, script26, script27, script28 };
        backGrounds = new GameObject[] { back1, back2, back3, back4, back5, back6, back7, back8, back9, back10 };
        aliExpressions = new Sprite[] {ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10, ali11, ali12, ali13, ali14, ali15, ali16, ali17, ali18, ali19, ali20, ali21,
           ali22, ali23, ali24, ali25, ali26, ali27, ali28 };
        transform.position = new Vector3(11, -1.45f, 0);
        Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
    }


    void Update()
    {

        if (aliPhase < 28)
        {
            if (transform.position.x > 6)
            {
                advanceToScreen();
            }
            else
            {
                if(firstScriptInstance == false)
                {
                    firstScriptInstance = true;
                    Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                    rend.sprite = aliExpressions[aliPhase];
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    aliPhase++;
                    audio.Play();

                    if (aliPhase > 3 && aliPhase <= 23)
                    {
                        if (aliPhase != 5 && aliPhase != 7 && aliPhase != 9 && aliPhase != 12 && aliPhase != 13 && aliPhase != 15)
                        {
                            if (aliPhase >= 17 && aliPhase <= 20)
                            {

                            }
                            else
                            {
                                Instantiate(backGrounds[backGroundPhase], new Vector3(0, 0, 0), Quaternion.identity);
                                backGroundPhase++;
                            }
                        }
                    }
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
                FadeInOutFinalCutscene.fadeOut = true;
            }
        }
    }
}
