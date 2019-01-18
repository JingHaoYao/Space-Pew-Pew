using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAliScript : MonoBehaviour {
    public GameObject aliEndDialogue;

	void Start () {

	}
	
	void Update () {
		
	}

    private void OnDestroy()
    {
        Instantiate(aliEndDialogue, new Vector3(11, -1.45f, 0), Quaternion.identity);
    }
}
