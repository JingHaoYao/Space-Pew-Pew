using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButtonScript : MonoBehaviour
{
    public GameObject SettingsMenu, playButton, optionsButton, exitButton;

    public void transitionToStart()
    {
        SettingsMenu.SetActive(false);
        exitButton.SetActive(true);
        playButton.SetActive(true);
        optionsButton.SetActive(true);
    }
}