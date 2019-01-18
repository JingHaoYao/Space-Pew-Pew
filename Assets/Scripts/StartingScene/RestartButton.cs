using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {
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

    public void restart()
    {

        goBackToCheckPoint();
        if (CheckPoints.passedSixthCheckPoint == false && CheckPoints.passedDecisionStage == false)
        {
            SceneManager.LoadScene("MainGameScene");
        }
        PlayerMovement.bombCount = 1;
        PlayerMovement.pierceCount = 1;
        PlayerMovement.spreadCount = 1;
        PlayerLife.lives = 3;
        GameManager.bossMode = false;
        FirstBossScript.bossHealth = 20;

        //SecondBoss:
        SecondBossScript.bossHealth = 20;
        SecondBossScript.doHitFrames = false;
        SecondBossScript.fireCannon = false;
        StormLightningFlash.dontFire = false;
        StormLightningFlash.lightningEffect = false;

        //ThirdBoss:
        ThirdBossScript.bossHealth = 20;
        ThirdBossScript.spiritBossHealth = 200;
        ThirdBossScript.aliSecondDialogue = false;
        ThirdBossScript.backToBlack = false;
        ThirdBossScript.shieldOff = false;
        ThirdBossScript.backToBlack = false;
        AliThirdBossScript.startBossFight = false;
        PlayerMovement.overClocked = false;
        LightningEffect.endLightningEffect = false;
        LightningEffect.startLightningEffect = false;
        LightningClash.revealBoss = false;

        //FourthBoss:
        FourthBossScript.powerCoreDestroyed = false;
        FourthBossScript.fireTurret = false;
        FourthBossScript.whatTurretFire = 0;
        FourthBossScript.bossFireLaser = false;
        BackBasePlate.backPlateBroken = false;
        BackBasePlate.backRepair = false;
        BackBasePlate.numHit = 0;
        FrontBasePlate.frontPlateBroken = false;
        FrontBasePlate.frontRepair = false;
        FrontBasePlate.numHit = 0;
        FrontPowerCore.powerCoreHealth = 5;
        BackPowerCore.powerCoreHealth = 5;
        AliIntroDialogue.startBossFight = false;

        //FifthBoss:

        //SixthBoss:
        LightningCell.cellHealth = 20;
        SixthBossScript.bossFightStarted = false;
        SixthBossScript.launchNapalm = false;
        SixthBossScript.numCoresDestroyed = 0;
        SixthBossScript.rocketNumber = 0;
        SixthBossScript.whichBall = 0;
        SixthBossScript.whichLauncher = 0;

        //SeventhBoss
        SeventhBossIntroDialogue.startBossFight = false;

        PauseMenuScript.gameIsPaused = false;
    }
}
