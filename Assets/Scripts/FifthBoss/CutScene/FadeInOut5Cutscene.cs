using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut5Cutscene : MonoBehaviour {
    Animator animator;
    public static bool fadeOut = false;

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3.5f);
        GameManager.level = 26;
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
            animator.SetTrigger("FadeOut");
            StartCoroutine(FadeOut());
            fadeOut = false;
        }
    }
}
