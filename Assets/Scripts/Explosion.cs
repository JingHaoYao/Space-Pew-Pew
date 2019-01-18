using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip explosionSound;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, 1);
        audioSource.PlayOneShot(explosionSound, 1);
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "FirstBoss" && collision.gameObject.name != "FirstBossShield" && 
            collision.gameObject.name != "FirstBossShield" && collision.gameObject.name != "PirateCannon1" &&
            collision.gameObject.name != "PirateCannon2" && collision.gameObject.name != "PirateCannon3" &&
            collision.gameObject.name != "ThirdBoss" && collision.gameObject.name != "LaserThirdBoss(Clone)"
            && collision.gameObject.name != "ThirdBossShield" && collision.gameObject.name != "ThirdBossSpirit(Clone)"
            && collision.gameObject.name != "FrontBasePlate" && collision.gameObject.name != "BackBasePlate" && collision.gameObject.name != "PowerCoreFront"
            && collision.gameObject.name != "PowerCoreBack" && collision.gameObject.name != "FifthBoss" && collision.gameObject.name != "LaserShield" &&
            collision.gameObject.name != "SideLightningLeft(Clone)" && collision.gameObject.name != "SideLightningRight(Clone)"
            && collision.gameObject.name != "SixthBossCore1" && collision.gameObject.name != "SixthBossCore2" && collision.gameObject.name != "SixthBossCore3" && collision.gameObject.name != "SixthBossCore4"
            && collision.gameObject.name != "SixthBossCore5" && collision.gameObject.name != "SixthBossCore6" && collision.gameObject.name != "SixthBossCore7" && collision.gameObject.name != "SixthBossCore8"
            && collision.gameObject.name != "NapalmShot(Clone)" && collision.gameObject.name != "NapalmShotCollision(Clone)" && collision.gameObject.name != "SixthBossPowerCell")
        {
            Destroy(collision.gameObject);
        }
    }
}
