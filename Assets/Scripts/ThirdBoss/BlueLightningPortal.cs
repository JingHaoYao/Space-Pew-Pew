using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLightningPortal : MonoBehaviour {
    bool instantiatedLightningSideBar = false;
    public GameObject lightningSideBar;
	void Start () {
        Destroy(this.gameObject, 1.333f);
	}

	void Update () {
        if(GameObject.Find("A.L.I OverClock(Clone)") && instantiatedLightningSideBar == false)
        {
            Instantiate(lightningSideBar, new Vector3(-7.42f, -4.9f, 0f), Quaternion.identity);
            instantiatedLightningSideBar = true;
        }
        transform.position = GameObject.Find("PlayerSpaceShip").transform.position;
	}
}
