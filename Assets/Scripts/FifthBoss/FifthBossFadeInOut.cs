using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FifthBossFadeInOut : MonoBehaviour {
    Animator animator;
    public static bool fadeOut = false;

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(5f);
        GameManager.beatSixthBoss = true;
        GameManager.bossMode = false;
        CheckPoints.passedFifthCheckPoint = true;
        PlayerLife.lives = 3;
        GameManager.level = 26;
        SceneManager.LoadScene("SixthBossCutScene");
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (fadeOut == true)
        {
            animator.SetTrigger("FadeOut");
            StartCoroutine(FadeOut());
            fadeOut = false;
        }
    }
}
