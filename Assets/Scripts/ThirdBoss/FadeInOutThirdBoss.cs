using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutThirdBoss : MonoBehaviour {
    Animator animator;
    public static bool fadeOut = false;

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3.5f);
        PlayerMovement.overClocked = false;
        GameManager.beatThirdBoss = true;
        GameManager.bossMode = false;
        PlayerLife.lives = 3;
        SceneManager.LoadScene("MainGameScene");
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (fadeOut == true)
        {
            CheckPoints.passedThirdCheckpoint = true;
            animator.SetTrigger("FadeOut");
            StartCoroutine(FadeOut());
            fadeOut = false;
        }
    }
}
