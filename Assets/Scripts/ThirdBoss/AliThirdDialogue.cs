using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliThirdDialogue : MonoBehaviour {
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10, ali11, ali12, ali13, ali14, ali15, ali16, ali17, ali18;
    Sprite[] aliExpressions;
    public GameObject script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12, script13, script14, script15, script16, script17, script18;
    GameObject[] aliLines;
    public GameObject thirdBossPersona;
    public static int endThirdBossDialogue = 0;
    bool firstScriptInstant = false;
    public GameObject fToAdvance;

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
        aliExpressions = new Sprite[] { ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10, ali11, ali12, ali13, ali14, ali15, ali16, ali17, ali18 };
        aliLines = new GameObject[] { script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12, script13, script14, script15, script16, script17, script18 };
        gameObject.SetActive(false);
        transform.position = new Vector3(11, -1.45f, 0);
        rend.sprite = aliExpressions[endThirdBossDialogue];
    }

    void Update()
    {
        if (endThirdBossDialogue < 18)
        {
            if(endThirdBossDialogue == 7)
            {
                thirdBossPersona.SetActive(true);
            }

            if (transform.position.x > 6)
            {
                advanceToScreen();
            }
            else
            {
                if (firstScriptInstant == false)
                {
                    Instantiate(aliLines[endThirdBossDialogue], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                    Instantiate(fToAdvance, new Vector3(0.5f, 1.5f, 0f), Quaternion.identity);
                    firstScriptInstant = true;
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    endThirdBossDialogue++;
                    audio.Play();
                    Instantiate(aliLines[endThirdBossDialogue], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                    rend.sprite = aliExpressions[endThirdBossDialogue];
                }
            }
        }
        else
        {
            if (transform.position.x < 11)
            {
                advanceOutScreen();
                FadeInOutThirdBoss.fadeOut = true;
            }
        }
    }
}
