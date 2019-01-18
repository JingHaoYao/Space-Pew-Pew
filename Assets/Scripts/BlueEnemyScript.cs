using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "DuckyProjectile(Clone)" && collision.gameObject.name != "EnemyBullet(Clone)"
            && collision.gameObject.name != "FirstBoss")
        {
            Destroy(this.gameObject);
            if (collision.gameObject.name == "PiercingShot(Clone)" || collision.gameObject.name == "PlayerSpaceShip" 
                || collision.gameObject.name == "Explosion(Clone)" || collision.gameObject.name == "DuckyExplosion(Clone)" 
                || collision.gameObject.name == "FirstBoss" || collision.gameObject.name == "DuckyProjectile(Clone)")
            {
            }
            else
            {
                Destroy(collision.gameObject);
            }
            if ((PlayerMovement.pierceCount + PlayerMovement.spreadCount + PlayerMovement.bombCount) < 9)
                PlayerMovement.pierceCount++;
        }
    }
}
