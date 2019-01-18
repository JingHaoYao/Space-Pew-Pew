using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AliThankYou : MonoBehaviour {

    public GameObject thankYou;
    bool hasSet = false;
    bool tapped = false;
    AudioSource aud;

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
		transform.position = transform.position = new Vector3(11, -1.45f, 0);
        aud = GetComponent<AudioSource>();
    }

	void Update () {
        if(tapped == false)
        {
            if (transform.position.x > 6)
            {
                advanceToScreen();
            }
            else
            {
                if (hasSet == false)
                {
                    Instantiate(thankYou, new Vector3(0.5f, 3.5f, 0), Quaternion.identity);
                    aud.Play();
                    hasSet = true;
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    tapped = true;
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
                FadeInOutDecisionStage.fadeOut = true;
            }
        }
	}
}
