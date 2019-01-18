using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhBossScript : MonoBehaviour {
    public GameObject solidObstacleLeft1, solidObstacleLeft2, solidObstacleLeft;
    public GameObject solidObstacleRight1, solidObstacleRight2, solidObstacleRight3;
    GameObject[] rightSolList, leftSolList, mineList, backgroundObstacleList, midbackList;
    public GameObject torpedoTarget, leftTurret, rightTurret, leftTurretPlatform, rightTurretPlatform;
    public GameObject redMine, blueMine, greenMine;
    public GameObject stasisShip;
    public GameObject seventhBossEnd;
    public GameObject backGroundObstacle1, backGroundObstacle2, backGroundObstacle3;
    public GameObject back1, back2, back3, back4;

    public static bool bossEnded = false;

    int[] targetPositions;
    int[] minePositions;

    float periodUntilDone = 0;
    public float waitTime = 120;

    float obstaclePeriod = 0;
    float obstacleWait = 5;

    float torpedoPeriod = 0;
    float torpedoWait = 10;

    bool torpedoFiring = false;
    int torpedoNumber = 5;

    float stasisShipPeriod = 13;

    public static int backGround1 = 0;

    float periodBackground = 0;
    float waitTimeBackground = 5;


    bool laserPlacementAlready(int[] laserEndPositions0, int index)
    {
        for (int i = index - 1; i >= 0; i--)
        {
            if (laserEndPositions0[index] == laserEndPositions0[i])
            {
                return true;
            }
        }
        return false;
    }

    void setMinePositions1(int[] laserEndPositions0)
    {
        for (int i = 0; i < 5; i++)
        {
            laserEndPositions0[i] = 0;
        }

        for (int i = 0; i < 5; i++)
        {
            laserEndPositions0[i] = Random.Range(1, 16);
            while (laserPlacementAlready(laserEndPositions0, i))
            {
                laserEndPositions0[i] = Random.Range(1, 16);
            }
        }
    }

    void setMinePositions2(int[] laserEndPositions0)
    {
        for (int i = 0; i < 3; i++)
        {
            laserEndPositions0[i] = 0;
        }

        for (int i = 0; i < 3; i++)
        {
            laserEndPositions0[i] = Random.Range(6, 10);
            while (laserPlacementAlready(laserEndPositions0, i))
            {
                laserEndPositions0[i] = Random.Range(6, 10);
            }
        }
    }

    void setTargetPositions(int[] laserEndPositions0)
    {
        for (int i = 0; i < 8; i++)
        {
            laserEndPositions0[i] = 0;
        }

        for (int i = 0; i < 8; i++)
        {
            laserEndPositions0[i] = Random.Range(1, 16);
            while (laserPlacementAlready(laserEndPositions0, i))
            {
                laserEndPositions0[i] = Random.Range(1, 16);
            }
        }
    }

    void Start () {
        rightSolList = new GameObject[] { solidObstacleRight1, solidObstacleRight2, solidObstacleRight3 };
        leftSolList = new GameObject[] { solidObstacleLeft1, solidObstacleLeft2, solidObstacleLeft };
        mineList = new GameObject[] { redMine, blueMine, greenMine };
        midbackList = new GameObject[] { back1, back2, back3, back4 };
        backgroundObstacleList = new GameObject[] { backGroundObstacle1, backGroundObstacle2, backGroundObstacle3 };
        targetPositions = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0};
        minePositions = new int[5] { 0, 0, 0, 0, 0};
        seventhBossEnd.SetActive(false);
	}

	void Update () {
		if(SeventhBossIntroDialogue.startBossFight == true)
        {
            if (periodUntilDone < waitTime)
            {
                periodUntilDone += Time.deltaTime;
                obstaclePeriod += Time.deltaTime;
                torpedoPeriod += Time.deltaTime;
                periodBackground += Time.deltaTime;

                if(periodBackground >= waitTimeBackground)
                {
                    periodBackground = 0;
                    waitTimeBackground = Random.Range(0.3f, 2.0f);
                    backGround1 = Random.Range(1, 3);

                    if(backGround1 == 1)
                    {
                        Instantiate(backgroundObstacleList[Random.Range(0, 3)], new Vector3(-5.4f, 15f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(backgroundObstacleList[Random.Range(0, 3)], new Vector3(7.4f, 15f, 0), Quaternion.identity);
                    }

                    Instantiate(midbackList[Random.Range(0, 4)], new Vector3(Random.Range(-4.6f, 5.6f), 15f, 0), Quaternion.identity);
                }

                if(periodUntilDone >= 60)
                {
                    if(torpedoNumber == 5)
                    {
                        torpedoNumber = 8;
                    }

                    stasisShipPeriod += Time.deltaTime;
                    if(stasisShipPeriod >= 15)
                    {
                        stasisShipPeriod = 0;
                        Instantiate(stasisShip, new Vector3(0.5f, 6f, 0), Quaternion.identity);
                    }

                }

                if(torpedoPeriod >= torpedoWait)
                {
                    torpedoPeriod = 0;
                    setTargetPositions(targetPositions);
                    for (int i = 0; i < torpedoNumber; i++)
                    {
                        Instantiate(torpedoTarget, new Vector3(-7.5f + targetPositions[i], -4.5f, 0), Quaternion.identity);
                    }
                }

                if (obstaclePeriod >= obstacleWait)
                {
                    obstaclePeriod = 0;
                    obstacleWait = Random.Range(.5f, 2.0f);
                    int whichPreset = Random.Range(1, 20);

                    if (whichPreset == 1)
                    {
                        Instantiate(leftSolList[Random.Range(0, 3)], new Vector3(-3.6f, 30f, 0), Quaternion.identity);
                    }
                    else if (whichPreset == 2)
                    {
                        Instantiate(rightSolList[Random.Range(0, 3)], new Vector3(4.6f, 30f, 0), Quaternion.identity);
                    }
                    else if (whichPreset == 3)
                    {
                        Instantiate(leftTurret, new Vector3(-6.4f, 30f, 0), Quaternion.identity);
                        Instantiate(leftTurretPlatform, new Vector3(-6.7f, 30f, 0), Quaternion.identity);
                    }
                    else if (whichPreset == 4)
                    {
                        Instantiate(rightTurret, new Vector3(7.4f, 30f, 0), Quaternion.identity);
                        Instantiate(rightTurretPlatform, new Vector3(7.7f, 30f, 0), Quaternion.identity);
                    }
                    else if (whichPreset == 5)
                    {
                        Instantiate(rightSolList[Random.Range(0, 3)], new Vector3(4.6f, 30f, 0), Quaternion.identity);
                        Instantiate(leftSolList[Random.Range(0, 3)], new Vector3(-3.6f, 30f, 0), Quaternion.identity);
                    }
                    else if (whichPreset == 6 || whichPreset == 7)
                    {
                        setMinePositions1(minePositions);
                        for (int i = 0; i < 5; i++)
                        {
                            Instantiate(mineList[Random.Range(0,3)], new Vector3(-7.5f + minePositions[i], 30f, 0), Quaternion.identity);
                        }
                    }
                    else if (whichPreset == 8)
                    {
                        Instantiate(rightSolList[Random.Range(0, 3)], new Vector3(4.6f, 30f, 0), Quaternion.identity);
                        Instantiate(leftSolList[Random.Range(0, 3)], new Vector3(-3.6f, 30f, 0), Quaternion.identity);
                        setMinePositions2(minePositions);
                        for (int i = 0; i < 3; i++)
                        {
                            Instantiate(mineList[Random.Range(0, 3)], new Vector3(-7.5f + minePositions[i], 30f, 0), Quaternion.identity);
                        }
                    }
                    else if (whichPreset == 9 || whichPreset == 10)
                    {
                        Instantiate(rightSolList[Random.Range(0, 3)], new Vector3(4.6f, 30f, 0), Quaternion.identity);
                        Instantiate(leftSolList[Random.Range(0, 3)], new Vector3(-3.6f, 30f, 0), Quaternion.identity);
                    }
                    else if (whichPreset == 11)
                    {
                        Instantiate(rightSolList[Random.Range(0, 3)], new Vector3(4.6f, 30f, 0), Quaternion.identity);
                        Instantiate(leftSolList[Random.Range(0, 3)], new Vector3(-3.6f, 30f, 0), Quaternion.identity);
                        setMinePositions2(minePositions);
                        for (int i = 0; i < 2; i++)
                        {
                            Instantiate(mineList[Random.Range(0, 3)], new Vector3(-7.5f + minePositions[i], 30f, 0), Quaternion.identity);
                        }
                    }
                    else if (whichPreset == 12 || whichPreset == 13)
                    {
                        Instantiate(leftTurret, new Vector3(-6.4f, 30f, 0), Quaternion.identity);
                        Instantiate(leftTurretPlatform, new Vector3(-6.7f, 30f, 0), Quaternion.identity);
                        Instantiate(rightSolList[Random.Range(0, 3)], new Vector3(4.6f, 30f, 0), Quaternion.identity);
                    }
                    else if (whichPreset == 14 || whichPreset == 15)
                    {
                        Instantiate(rightTurret, new Vector3(7.4f, 30f, 0), Quaternion.identity);
                        Instantiate(rightTurretPlatform, new Vector3(7.7f, 30f, 0), Quaternion.identity);
                        Instantiate(leftSolList[Random.Range(0, 3)], new Vector3(-3.6f, 30f, 0), Quaternion.identity);
                    }
                    else if(whichPreset == 16 || whichPreset == 17)
                    {
                        Instantiate(rightTurret, new Vector3(7.4f, 30f, 0), Quaternion.identity);
                        Instantiate(rightTurretPlatform, new Vector3(7.7f, 30f, 0), Quaternion.identity);
                        Instantiate(leftTurret, new Vector3(-6.4f, 30f, 0), Quaternion.identity);
                        Instantiate(leftTurretPlatform, new Vector3(-6.7f, 30f, 0), Quaternion.identity);
                    }
                    else if(whichPreset == 18)
                    {
                        Instantiate(rightTurret, new Vector3(7.4f, 30f, 0), Quaternion.identity);
                        Instantiate(rightTurretPlatform, new Vector3(7.7f, 30f, 0), Quaternion.identity);
                        Instantiate(leftSolList[Random.Range(0, 3)], new Vector3(-3.6f, 30f, 0), Quaternion.identity);
                        setMinePositions2(minePositions);
                        for (int i = 0; i < 3; i++)
                        {
                            Instantiate(mineList[Random.Range(0, 3)], new Vector3(-7.5f + minePositions[i], 30f, 0), Quaternion.identity);
                        }
                    }
                    else
                    {
                        Instantiate(leftTurret, new Vector3(-6.4f, 30f, 0), Quaternion.identity);
                        Instantiate(leftTurretPlatform, new Vector3(-6.7f, 30f, 0), Quaternion.identity);
                        Instantiate(rightSolList[Random.Range(0, 3)], new Vector3(4.6f, 30f, 0), Quaternion.identity);
                        setMinePositions2(minePositions);
                        for (int i = 0; i < 3; i++)
                        {
                            Instantiate(mineList[Random.Range(0, 3)], new Vector3(-7.5f + minePositions[i], 30f, 0), Quaternion.identity);
                        }
                    }
                }
            }
            else
            {
                bossEnded = true;
                seventhBossEnd.SetActive(true);
            }
        }
	}
}
