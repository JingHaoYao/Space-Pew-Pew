using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveData {
    public bool firstPlay, beatFirstBoss, beatSecondBoss, beatThirdBoss, beatFourthBoss, beatFifthBoss, beatSixthBoss, passedDecisionStage;

    public SaveData (CheckPoints checkPoints)
    {
        firstPlay = CheckPoints.firstPlay;
        beatFirstBoss = CheckPoints.passedFirstCheckpoint;
        beatSecondBoss = CheckPoints.passedSecondCheckpoint;
        beatThirdBoss = CheckPoints.passedThirdCheckpoint;
        beatFourthBoss = CheckPoints.passedFourthCheckpoint;
        beatFifthBoss = CheckPoints.passedFifthCheckPoint;
        beatSixthBoss = CheckPoints.passedSixthCheckPoint;
        passedDecisionStage = CheckPoints.passedDecisionStage;
    }

}
