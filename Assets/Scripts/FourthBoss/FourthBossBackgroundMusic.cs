using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthBossBackgroundMusic : MonoBehaviour {

    AudioSource audioSource;
    bool hasSet = false;
    bool hasSet2 = false;

    IEnumerator fadeOutAudio()
    {
        for (float i = 1; i >= 0; i -= 0.05f)
        {
            audioSource.volume = i;
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.volume = 0;
    }

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		if(AliIntroDialogue.startBossFight == true && hasSet == false)
        {
            audioSource.Play();
            hasSet = true;
        }

        if(BackPowerCore.powerCoreHealth == 0 && FrontPowerCore.powerCoreHealth == 0)
        {
            if(hasSet2 == false)
            {
                StartCoroutine(fadeOutAudio());
                hasSet2 = true;
            }
        }
	}
}
