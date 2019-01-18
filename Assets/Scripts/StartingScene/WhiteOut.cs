using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteOut : MonoBehaviour {
    SpriteRenderer rend;
    float period = 0;
    bool flashed = false;
    public GameObject backGround;
    public GameObject logo, startButton, exitButton, optionsButton, settingsMenu, resetSave;
    AudioSource audioSource;
    public GameObject areyousure;

    IEnumerator flash()
    {
        Color c = rend.material.color;
        c.a = 1;
        c.b = 1;
        c.g = 1;
        c.a = 0;
        for (float f = 0; f <= 1.05; f += 0.05f)
        {
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(3f);
        Instantiate(backGround, new Vector3(0, 0, 0), Quaternion.identity);
        logo.SetActive(true);
        startButton.SetActive(true);
        optionsButton.SetActive(true);
        exitButton.SetActive(true);
        audioSource.Play();
        resetSave.SetActive(true);
        for (float f = 1; f >= 0; f -= 0.05f)
        {
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.15f);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        c.r = 1f;
        c.b = 1f;
        c.g = 1f;
        rend.material.color = c;
        logo.SetActive(false);
        startButton.SetActive(false);
        optionsButton.SetActive(false);
        exitButton.SetActive(false);
        settingsMenu.SetActive(false);
        resetSave.SetActive(false);
        areyousure.SetActive(false);
    }

    void Update()
    {
        period += Time.deltaTime;
        if(period >= 0.833f)
        {
            if(flashed == false)
            {
                StartCoroutine(flash());
                flashed = true;
            }
        }
    }
}
