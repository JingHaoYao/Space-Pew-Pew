using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSaveButton : MonoBehaviour {
    public Sprite Hover, noHover;
    SpriteRenderer rend;
    public GameObject areyousure;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        areyousure.SetActive(false);
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
        areyousure.SetActive(true);
    }
}
