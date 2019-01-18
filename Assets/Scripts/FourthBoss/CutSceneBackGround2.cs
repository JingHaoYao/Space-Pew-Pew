using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneBackGround2 : MonoBehaviour {
    Animator animator;
    int count = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(count == 1)
            {
                animator.SetTrigger("FadeOut");
                Destroy(this.gameObject, 0.833f);
            }
            count++;
        }
    }
}
