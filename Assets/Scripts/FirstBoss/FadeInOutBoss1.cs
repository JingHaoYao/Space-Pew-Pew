using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutBoss1 : MonoBehaviour {
    Animator animator;

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3.5f);
        PlayerLife.lives = 3;
        SceneManager.LoadScene("MainGameScene");
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        if (GameObject.Find("BossExploding(Clone)"))
        {
            CheckPoints.passedFirstCheckpoint = true;
            animator.SetTrigger("FadeOut");
            StartCoroutine(FadeOut());
        }
    }
}
