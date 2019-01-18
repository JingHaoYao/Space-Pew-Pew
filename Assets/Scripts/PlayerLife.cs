using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static int lives = 3;
    public GameObject Explosion;
    public bool alive = true;
    public SpriteRenderer rend;
    public BoxCollider2D hitbox;
    Vector3 startPosition = new Vector3(0, -4.5f, 0);
    public GameObject playerDies;
    bool instantiatedDeath = false;

    void Start()
    {
        rend.enabled = true;
        hitbox.enabled = true;
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(lives < 0){
            StartCoroutine(delay());
            rend.enabled = false;
            hitbox.enabled = false;
            if(instantiatedDeath == false)
            {
                Instantiate(playerDies, transform.position, Quaternion.identity);
                rend.enabled = false;
                instantiatedDeath = true;
            }
            return;
        }

        if (GameObject.Find("PirateShipBaseBurning(Clone)") || GameObject.Find("BossExploding"))
        {
            hitbox.enabled = false;
        }

        if((FrontPowerCore.powerCoreHealth <= 0 && BackPowerCore.powerCoreHealth <= 0))
        {
            hitbox.enabled = false;
        }

        if (GameObject.Find("FifthBossDefeated(Clone)"))
        {
            hitbox.enabled = false;
        }

        if(LightningCell.cellHealth <= 0)
        {
            hitbox.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "DuckyProjectile(Clone)" && collision.gameObject.name != "BlueDrop(Clone)"
            && collision.gameObject.name != "RedDrop(Clone)" && collision.gameObject.name != "GreenDrop(Clone)")
        {
            rend.enabled = false;
            hitbox.enabled = false;
            lives--;
            if (lives < 0)
            {
                return;
            }
            Instantiate(Explosion, transform.position, Quaternion.identity);
            transform.position = startPosition;
            StartCoroutine(InvincibilityFrames());
        }
    }

    public IEnumerator InvincibilityFrames(){
        for (int i = 6; i > 0; i-- )
        {
            yield return new WaitForSeconds(.2f);
            rend.enabled = true;
            yield return new WaitForSeconds(.2f);
            rend.enabled = false;
        }
        rend.enabled = true;
        hitbox.enabled = true;
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameOver");
    }
}