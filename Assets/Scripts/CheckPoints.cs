using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour {
    public static bool firstPlay = false;
    public static bool passedFirstCheckpoint = false;
    public static bool passedSecondCheckpoint = false;
    public static bool passedThirdCheckpoint = false;
    public static bool passedFourthCheckpoint = false;
    public static bool passedFifthCheckPoint = false;
    public static bool passedSixthCheckPoint = false;
    public static bool passedDecisionStage = false;

    public static bool forcedSave = false;
    
    public void saveData()
    {
        SaveSystem.saveData(this);
    }

    public void loadPlayer()
    {
        SaveData data = SaveSystem.loadData();
        firstPlay = data.firstPlay;
        passedFirstCheckpoint = data.beatFirstBoss;
        passedSecondCheckpoint = data.beatSecondBoss;
        passedThirdCheckpoint = data.beatThirdBoss;
        passedFourthCheckpoint = data.beatFourthBoss;
        passedFifthCheckPoint = data.beatFifthBoss;
        passedSixthCheckPoint = data.beatSixthBoss;
        passedDecisionStage = data.passedDecisionStage;
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "StartingScreen")
        {
            loadPlayer();
        }
        else
        {
            saveData();
        }
    }

    private void Update()
    {
        if(forcedSave == true)
        {
            forcedSave = false;
            saveData();
            SceneManager.LoadScene("StartingScreen");
        }
    }
}
