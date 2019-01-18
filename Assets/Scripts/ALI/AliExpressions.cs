using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliExpressions : MonoBehaviour {
    SpriteRenderer rend;
    AudioSource audio;
    public Sprite ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10, ali11, ali12, ali13, ali14, ali15, ali16, ali17, ali18;
    Sprite[] aliExpressions;
    public GameObject script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12, script13, script14,
                      script15, script16, script17, scrip18;
    GameObject[] aliLines;
    public GameObject highlightBox1, highlightBox2;
    int aliPhase = 0;
    public static bool loadMainScene = false;

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

	void Start () {
        rend = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        aliExpressions = new Sprite[] { ali1, ali2, ali3, ali4, ali5, ali6, ali7, ali8, ali9, ali10, ali11, ali12, ali13, ali14, ali15, ali16, ali17, ali18 };
        aliLines = new GameObject[] { script1, script2, script3, script4, script5, script6, script7, script8, script9, script10, script11, script12,
                                      script13, script14,script15, script16, script17, scrip18};
        transform.position = new Vector3(11, -1.45f, 0);
        Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
        PlayerMovement.pierceCount = 3;
        PlayerMovement.bombCount = 3;
        PlayerMovement.spreadCount = 3;
    }

	void Update () {
        if (aliPhase < 18)
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
                    if (aliPhase == 5)
                    {
                        Instantiate(highlightBox1, new Vector3(-7.49f, -3.76f, 0), Quaternion.identity);
                    }
                    else if (aliPhase == 6)
                    {
                        Instantiate(highlightBox2, new Vector3(-7.47f, 1.88f, 0), Quaternion.identity);
                    }
                    Instantiate(aliLines[aliPhase], new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                    rend.sprite = aliExpressions[aliPhase];
                }
            }
        }
        else
        {
            if(transform.position.x < 11)
            {
                advanceOutScreen();
            }
            else
            {
                CheckPoints.firstPlay = true;
                loadMainScene = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckPoints.firstPlay = true;
            loadMainScene = true;
        }
	}
}
