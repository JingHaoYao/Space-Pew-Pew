using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SixthBossFadeInOut : MonoBehaviour {

    Animator animator;
    public static bool fadeOut = false;

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(5f);
        GameManager.beatFifthBoss = true;
        GameManager.bossMode = false;
        CheckPoints.passedSixthCheckPoint = true;
        PlayerLife.lives = 3;
        GameManager.level = 26;
        LightningCell.cellHealth = 20;
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
