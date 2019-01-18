using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public static int pierceCount = 1, spreadCount = 1, bombCount = 1;
    public float speed;
    public AudioClip PierceAudio, SpreadAudio, BombAudio;
    private AudioSource audioSource;
    float spriteLifeTime = 0;
    SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite piercingSprite;
    public Sprite spreadSprite;
    public Sprite rocketSprite;
    public GameObject piercingShot;
    public GameObject spreadShotMid;
    public GameObject spreadShotLeft;
    public GameObject spreadShotRight;
    public GameObject rocketShot;
    public static bool overClocked = false;
    public static int angleSpread = 0;
	
	void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void FirePiercingshot()
    {
        Instantiate(piercingShot, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
    }

    void FireSpreadShot()
    {
        for(int i = 0; i < 5; i++)
        {
            angleSpread = 60 + 15 * i;
            Instantiate(spreadShotMid, transform.position + new Vector3(0, 0.75f, 0), Quaternion.Euler(0, 0, angleSpread - 90));
        }
    }

    void FireRocketShot()
    {
        Instantiate(rocketShot, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
    }
    
    void UpdateSprite()
    {
        if (AliDialogue.opportunityGone == false)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (pierceCount > 0 || overClocked == true)
                {
                    spriteRenderer.sprite = piercingSprite;
                    audioSource.PlayOneShot(PierceAudio, 1);
                    spriteLifeTime = 0.15f;
                    FirePiercingshot();
                    if (overClocked == false)
                        pierceCount--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                if (spreadCount > 0 || overClocked == true)
                {
                    spriteRenderer.sprite = spreadSprite;
                    audioSource.PlayOneShot(SpreadAudio, 1);
                    spriteLifeTime = 0.15f;
                    FireSpreadShot();
                    if (overClocked == false)
                        spreadCount--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                if (bombCount > 0 || overClocked == true)
                {
                    spriteRenderer.sprite = rocketSprite;
                    audioSource.PlayOneShot(BombAudio, 1);
                    spriteLifeTime = 0.15f;
                    FireRocketShot();
                    if (overClocked == false)
                        bombCount--;
                }
            }

            spriteLifeTime -= Time.deltaTime;
            if (spriteLifeTime <= 0)
            {
                spriteRenderer.sprite = idleSprite;
            }
        }
    }
	
	void Update(){
        UpdateSprite();
        float step = speed * Time.deltaTime;
        Vector3 newPos = transform.position;
        if (GameObject.Find("StasisLock") || GameObject.Find("StasisLock(Clone)"))
        {
            //do nothing
        }
        else
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                newPos += Vector3.left * step;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                newPos += Vector3.right * step;
            }
        }
        newPos.x = Mathf.Clamp(newPos.x, -6.5f,7.5f);
        transform.position = newPos;
	}
}
