using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutDecisionStage : MonoBehaviour {
    Animator animator;
    public static bool fadeOut = false;

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(5f);
        GameManager.bossMode = false;
        PlayerLife.lives = 3;
        GameManager.level = 26;
        if (AliDialogue.opportunityGone == false)
        {
            SceneManager.LoadScene("Credits");
        }
        else
        {
            SceneManager.LoadScene("SeventhBoss");
        }
        AliDialogue.opportunityGone = false;
        AliDialogue.coreShot = false;
        DestroyedFlash.flashOn = false;
    }

    void Start()
    {
        PlayerMovement.bombCount = PlayerMovement.pierceCount = PlayerMovement.spreadCount = 1;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (fadeOut == true)
        {
            animator.SetTrigger("FadeOut");
            StartCoroutine(FadeOut());
            fadeOut = false;
            CheckPoints.passedDecisionStage = true;
        }
    }
}
