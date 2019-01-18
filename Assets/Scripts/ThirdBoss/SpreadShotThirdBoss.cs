using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShotThirdBoss : MonoBehaviour {
    public GameObject lightningClash;
    float speedBullet = 8;
    float step = 0;
    float angleFire = GreenSummonPortal.angleFire;

	void Start () {
        step = speedBullet * Time.deltaTime;
	}

    void Update() {
        transform.position += new Vector3(Mathf.Cos(angleFire * Mathf.Deg2Rad), Mathf.Sin(angleFire * Mathf.Deg2Rad), 0) * step;
        if (transform.position.y < -5 || transform.position.x > 8 || transform.position.x < -7)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "SpreadShotMid(Clone)" || col.gameObject.name == "SpreadShotRight(Clone)" || col.gameObject.name == "SpreadShotLeft(Clone)")
        {
            BackFlash.flash = true;
            Destroy(this.gameObject);
            if (PlayerMovement.pierceCount + PlayerMovement.spreadCount + PlayerMovement.bombCount < 9)
            {
                PlayerMovement.spreadCount++;
            }
        }
        else if (col.gameObject.name == "PlayerSpaceShip")
        {

        }
        else
        {
            if (col.gameObject.name != "Explosion(Clone)")
                Destroy(col.gameObject);
        }
    }
}
