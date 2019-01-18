using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLightningStorm : MonoBehaviour {
    Animator animator;
    SpriteRenderer rend;
    public static bool lightningAway = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
    }

    void Update()
    {
        transform.position = GameObject.Find("StormCloudsRight").transform.position + new Vector3(0.3f,0,0);
        if(lightningAway == true)
        {
            animator.SetTrigger("Lightning");
            rend.enabled = true;
            lightningAway = false;
            WaterStorm.playStorm = true;
        }
    }
}
