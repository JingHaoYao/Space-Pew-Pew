using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtonScript : MonoBehaviour {
    public Sprite Hover, noHover;
    SpriteRenderer rend;
    public GameObject SettingsMenu, playButton, optionsButton, exitButton;
 
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        SettingsMenu.SetActive(false);
    }

    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (!GameObject.Find("AreYouSure"))
        {
            rend.sprite = Hover;
        }
    }

    private void OnMouseExit()
    {
        rend.sprite = noHover;
    }

    private void OnMouseDown()
    {
        if (!GameObject.Find("AreYouSure"))
        {
            SettingsMenu.SetActive(true);
            exitButton.SetActive(false);
            playButton.SetActive(false);
            optionsButton.SetActive(false);
        }
    }
}
