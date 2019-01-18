using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossALICutScene : MonoBehaviour
{
    AudioSource audio;
    Sprite[] aliExpressions;
    public GameObject script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12,
                      script13, script14, script15, script16, script17, script18, script19, script20, script21, script22, script23,
                      script24, script25, script26, script27, script28, script29;
    GameObject[] aliLines;

    GameObject[] backGrounds;
    public GameObject back1, back2, back3, back4, back5, back6, back7, back8, back9, back10, back11, back12, back13, back14, back15, back16, back17, 
                      back18, back19, back20, back21, back22, back23, back24, back25, back26, back27, back28, back29;
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
        audio = GetComponent<AudioSource>();
        aliLines = new GameObject[] { script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12,
                      script13, script14, script15, script16, script17, script18, script19, script20, script21, script22, script23,
                      script24, script25, script26, script27, script28, script29 };
        backGrounds = new GameObject[] { back1, back2, back3, back4, back5, back6, back7, back8, back9, back10, back11, back12, back13, back14, back15, back16, back17,
                                         back18, back19, back20, back21, back22, back23, back24, back25, back26, back27, back28, back29};
        transform.position = new Vector3(11, -1.45f, 0);
        Instantiate(backGrounds[aliPhase], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
    }


    void Update()
    {
        if (aliPhase < 29)
        {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    aliPhase++;
                    audio.Play();
                    if(aliPhase != 3 && aliPhase != 6 && aliPhase != 7 && aliPhase != 18 && aliPhase != 19
                        && aliPhase != 21 && aliPhase != 22 && aliPhase != 15 && aliPhase != 16)
                    {
                        if(aliPhase >= 10 && aliPhase <= 13)
                        {

                        }
                        else {
                            Instantiate(backGrounds[aliPhase], new Vector3(0, 0, 0), Quaternion.identity);
                        }
                    }
                    Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                }
        }
        else
        {
            if (transform.position.x < 11)
                advanceOutScreen();
            else
            {
                FadeInOutSixthBossCutScene.fadeOut = true;
            }
        }
    }
}
