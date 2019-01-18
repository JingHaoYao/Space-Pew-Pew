using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

	void Update () {
		if(gameIsPaused == false)
        {
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused == true)
            {
                gameIsPaused = false;
            }
            else
            {
                gameIsPaused = true;
            }
        }
	}
}
