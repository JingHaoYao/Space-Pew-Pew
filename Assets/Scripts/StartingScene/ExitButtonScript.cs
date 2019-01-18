using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : MonoBehaviour {
    public Sprite Hover, noHover;
    SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
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
            Application.Quit();
        }
    }
}
