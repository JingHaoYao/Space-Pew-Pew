using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutSeventhBoss : MonoBehaviour {
    Animator animator;
    public static bool fadeOut = false;

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("FinalCutScene");
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
