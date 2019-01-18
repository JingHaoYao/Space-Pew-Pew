using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPortal : MonoBehaviour {

    void Start()
    {
        Destroy(this.gameObject, 1.333f);
    }

    void Update()
    {
        ThirdBossScript.backToBlack = true;
    }

    private void OnDestroy()
    {
        ThirdBossScript.spiritExits = false;
        PlayerMovement.overClocked = false;
        ShipSpirit.aliSpoke = false;
    }
}
