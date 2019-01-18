using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
    public GameObject page1, page2, page3, page4;
    GameObject[] spriteList;
    float period = 0;
    int phase = 0;
    bool hasSet = false;

    IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("StartingScreen");
    }

    void Start () {
        spriteList = new GameObject[] { page1, page2, page3, page4 };
        Instantiate(spriteList[phase], new Vector3(0, 0, 0), Quaternion.identity);
	}

	void Update () {
        period += Time.deltaTime;
        if (phase < 3)
        {
            if (period >= 10)
            {
                period = 0;
                Instantiate(spriteList[phase + 1], new Vector3(0, 0, 0), Quaternion.identity);
                phase++;
                Debug.Log(phase);
            }
        }
        else
        {
            if(hasSet == false)
            {
                Debug.Log("FadeOut");
                hasSet = true;
                StartCoroutine(fadeOut());
            }
        }
	}
}
