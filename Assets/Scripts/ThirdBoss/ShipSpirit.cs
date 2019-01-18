using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpirit : MonoBehaviour {
    BoxCollider2D collider0;
    int counter = 0;
    public GameObject returnSpirit, deadSpirit;
    public static bool growLightning = false;
    float period = 0;
    public static bool aliSpoke = false;
    public GameObject aliOverClock;
    AudioSource audioSource;
    public AudioClip scream;

	void Start(){
        collider0 = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        collider0.enabled = false;
        period = 0;
        counter = 0;
        Instantiate(aliOverClock, new Vector3(11f, -1.45f, 0f), Quaternion.identity);
        aliSpoke = false;
    }

	void Update()
    {
        if(aliSpoke == true)
        {
            collider0.enabled = true;
            period += Time.deltaTime;
            if (counter >= 40 || period >= 5f)
            {
                collider0.enabled = false;
                Destroy(this.gameObject);
                Destroy(GameObject.Find("SpiritLightningEffect(Clone)"));
                Instantiate(returnSpirit, transform.position, Quaternion.identity);
                if (ThirdBossScript.spiritBossHealth <= 0)
                {
                    Instantiate(deadSpirit, transform.position, Quaternion.identity);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(scream);
        if(gameObject.name != "Explosion(Clone)")
        {
            Destroy(collision.gameObject);
        }
        ThirdBossScript.spiritBossHealth--;
        counter++;
        growLightning = true;
        CameraShake.spiritHit = true;
    }
}
