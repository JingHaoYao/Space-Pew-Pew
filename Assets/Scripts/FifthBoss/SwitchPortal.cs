using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPortal : MonoBehaviour {
    Animator animator;
    public GameObject switchLightning;

    void switchAmmo()
    {
        int whichSwitch = Random.Range(1, 4);
        if(whichSwitch == 1)
        {
            int temp = PlayerMovement.pierceCount;
            PlayerMovement.pierceCount = PlayerMovement.spreadCount;
            PlayerMovement.spreadCount = temp;
        }
        else if(whichSwitch == 2)
        {
            int temp = PlayerMovement.pierceCount;
            PlayerMovement.pierceCount = PlayerMovement.bombCount;
            PlayerMovement.bombCount = temp;
        }
        else
        {
            int temp = PlayerMovement.bombCount;
            PlayerMovement.bombCount = PlayerMovement.spreadCount;
            PlayerMovement.spreadCount = temp;
        }
    }

    IEnumerator animate()
    {
        yield return new WaitForSeconds(0.417f);
        animator.SetTrigger("Pulsing");
        Instantiate(switchLightning, transform.position + new Vector3(-0.8f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(1.083f / 4f);
        switchAmmo();
        yield return new WaitForSeconds(1.083f / 4f);
        animator.SetTrigger("PhaseOut");
        yield return new WaitForSeconds(0.417f);
        Destroy(this.gameObject);
    }

	void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine(animate());
	}

	void Update () {
		
	}
}
