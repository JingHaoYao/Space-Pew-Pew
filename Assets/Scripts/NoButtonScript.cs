using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButtonScript : MonoBehaviour {
    public GameObject areyousure;

    public void no()
    {
        areyousure.SetActive(false);
    }
}
