using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliDialogue : MonoBehaviour
{
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10;
    Sprite[] aliExpressions;
    public GameObject script1, script2, script3, script4, script5, script6, script7, script8, script9, script10;
    GameObject[] aliLines;
    public GameObject fToAdvance;
    int aliPhase = 0;
    float period1 = 0;
    float period2 = 0;
    float period3 = 0;
    bool firstScript1 = false;
    bool firstScript2 = false;
    bool firstScript3 = false;
    bool firstScript4 = false;
    bool firstScript5 = false;
    public float waitTime;
    public static bool opportunityGone = false;
    public static bool coreShot = false;

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
        aliExpressions = new Sprite[] { ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10 };
        aliLines = new GameObject[] { script1, script2, script3, script4, script5, script6, script7, script8, script9, script10 };
        transform.position = new Vector3(11, -1.45f, 0);
        rend.sprite = aliExpressions[aliPhase];
    }

    void Update()
    {
        if (coreShot == false)
        {
            if (aliPhase < 10)
            {
                if (transform.position.x > 6)
                {
                    advanceToScreen();
                }
                else
                {
                    if (opportunityGone == false)
                    {
                        if (aliPhase < 3)
                        {
                            if (firstScript1 == false)
                            {
                                firstScript1 = true;
                                audio.Play();
                                Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                                Instantiate(fToAdvance, new Vector3(0.5f, 1.5f, 0f), Quaternion.identity);
                                rend.sprite = aliExpressions[aliPhase];
                            }

                            if (Input.GetKeyDown(KeyCode.F))
                            {
                                aliPhase++;
                                if (aliPhase != 3)
                                {
                                    audio.Play();
                                    rend.sprite = aliExpressions[aliPhase];
                                    Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                                }
                            }
                        }
                        else
                        {
                            if (period1 <= waitTime)
                            {
                                period1 += Time.deltaTime;
                            }
                            else
                            {
                                if (aliPhase < 4)
                                {
                                    if (firstScript2 == false)
                                    {
                                        audio.Play();
                                        rend.sprite = aliExpressions[aliPhase];
                                        Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                                        firstScript2 = true;
                                    }

                                    if (Input.GetKeyDown(KeyCode.F))
                                    {
                                        aliPhase++;
                                    }
                                }
                                else
                                {
                                    if (period2 < waitTime)
                                    {
                                        period2 += Time.deltaTime;
                                    }
                                    else
                                    {
                                        if (aliPhase < 5)
                                        {
                                            if (firstScript3 == false)
                                            {
                                                audio.Play();
                                                Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                                                rend.sprite = aliExpressions[aliPhase];
                                                firstScript3 = true;
                                            }

                                            if (Input.GetKeyDown(KeyCode.F))
                                            {
                                                aliPhase++;
                                            }
                                        }
                                        else
                                        {
                                            if (period3 < waitTime)
                                            {
                                                period3 += Time.deltaTime;
                                            }
                                            else
                                            {
                                                opportunityGone = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (firstScript4 == false)
                        {
                            firstScript4 = true;
                            audio.Play();
                            Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                        }
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            aliPhase++;
                            audio.Play();
                            rend.sprite = aliExpressions[aliPhase];
                            Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                        }
                    }
                }
            }
            else
            {
                if (transform.position.x < 11)
                {
                    advanceOutScreen();
                }
                else
                {
                    FadeInOutDecisionStage.fadeOut = true;
                }
            }
        }
    }
}
