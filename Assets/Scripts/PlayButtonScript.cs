using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {
    public Sprite Hover1,noHover1;
    public Sprite hover2, nohover2;
    SpriteRenderer rend;

	void Start () {
        rend = GetComponent<SpriteRenderer>();
        if (CheckPoints.firstPlay == false)
        {
            rend.sprite = noHover1;
        }
        else
        {
            rend.sprite = nohover2;
        }
    }

	void Update () {
	
	}

    void goBackToCheckPoint()
    {
        if (CheckPoints.passedDecisionStage == true)
        {
            SeventhBossIntroDialogue.startBossFight = false;
            PlayerMovement.bombCount = 1;
            PlayerMovement.pierceCount = 1;
            PlayerMovement.spreadCount = 1;
            PlayerLife.lives = 3;
            SceneManager.LoadScene("SeventhBoss");
        }
        else if (CheckPoints.passedSixthCheckPoint == true)
        {
            AliDialogue.opportunityGone = false;
            AliDialogue.coreShot = false;
            DestroyedFlash.flashOn = false;
            SceneManager.LoadScene("DecisionStage");
        }
        else if (CheckPoints.passedFifthCheckPoint == true)
        {
            GameManager.level = 26;
            return;
        }
        else if (CheckPoints.passedFourthCheckpoint == true)
        {
            GameManager.level = 21;
            return;
        }
        else if (CheckPoints.passedThirdCheckpoint == true)
        {
            GameManager.level = 16;
            return;
        }
        else if (CheckPoints.passedSecondCheckpoint == true)
        {
            GameManager.level = 11;
            return;
        }
        else if (CheckPoints.passedFirstCheckpoint == true)
        {
            GameManager.level = 6;
            return;
        }
        else
        {
            GameManager.level = 1;
            return;
        }
    }

    private void OnMouseOver()
    {
        if (!GameObject.Find("AreYouSure"))
        {
            if (CheckPoints.firstPlay == false)
            {
                rend.sprite = Hover1;
            }
            else
            {
                rend.sprite = hover2;
            }
        }
    }

    private void OnMouseExit()
    {
            if (CheckPoints.firstPlay == false)
            {
                rend.sprite = noHover1;
            }
            else
            {
                rend.sprite = nohover2;
            }
    }
    private void OnMouseDown()
    {
        if (!GameObject.Find("AreYouSure"))
        {
            goBackToCheckPoint();
            if (CheckPoints.firstPlay == false)
            {
                SceneManager.LoadScene("TutorialScene");
            }
            else
            {
                SceneManager.LoadScene("MainGameScene");
            }

            PlayerMovement.bombCount = 1;
            PlayerMovement.pierceCount = 1;
            PlayerMovement.spreadCount = 1;
            PlayerLife.lives = 3;
            GameManager.bossMode = false;
        }
    }
}
