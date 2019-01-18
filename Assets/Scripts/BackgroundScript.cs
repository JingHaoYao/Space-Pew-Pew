using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

    Animator animator;
    public int numTaps = 1;
    int count = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (count == numTaps - 1)
            {
                animator.SetTrigger("FadeOut");
                Destroy(this.gameObject, 0.833f);
            }
            count++;
        }
    }
}
