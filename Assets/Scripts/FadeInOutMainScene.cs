using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutMainScene : MonoBehaviour {
    Animator animator;

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(9.5f);
        if (GameManager.level == 6 && GameManager.beatFirstBoss == false)
        {
            SceneManager.LoadScene("FirstBoss");
        }
        else if (GameManager.level == 11 && GameManager.beatSecondBoss == false)
        {
            SceneManager.LoadScene("SecondBoss");
        }
        else if(GameManager.level == 16 && GameManager.beatThirdBoss == false)
        {
            AliThirdBossScript.startBossFight = false;
            ThirdBossScript.aliSecondDialogue = false;
            SceneManager.LoadScene("ThirdBoss");
        }
        else if(GameManager.level == 21 && GameManager.beatFourthBoss == false)
        {
            SceneManager.LoadScene("FourthBoss");
        }
        else if(GameManager.level == 26 && GameManager.beatFifthBoss == false)
        {
            SceneManager.LoadScene("FifthBoss");
        }
        else if(GameManager.level == 31 && GameManager.beatSixthBoss == false)
        {
            SceneManager.LoadScene("SixthBoss");
        }
        else
        {
            PlayerMovement.pierceCount = 1;
            PlayerMovement.bombCount = 1;
            PlayerMovement.spreadCount = 1;
            SceneManager.LoadScene("MainGameScene");
        }
    }

    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(6);
        animator.SetTrigger("FadeOut");
    }


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.bossMode == true)
        {
            StartCoroutine(Wait1());
            StartCoroutine(FadeOut());
            AliExpressions.loadMainScene = false;
        }

        if(AliExpressions.loadMainScene == true)
        {
            animator.SetTrigger("FadeOut");
            StartCoroutine(FadeOut());
            AliExpressions.loadMainScene = false;
        }
    }
}
