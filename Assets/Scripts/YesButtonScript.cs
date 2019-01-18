using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesButtonScript : MonoBehaviour {

    public GameObject areyousure;

    public void yes()
    {
        CheckPoints.firstPlay = false;
        CheckPoints.passedDecisionStage = false;
        CheckPoints.passedSixthCheckPoint = false;
        CheckPoints.passedFifthCheckPoint = false;
        CheckPoints.passedFourthCheckpoint = false;
        CheckPoints.passedThirdCheckpoint = false;
        CheckPoints.passedSecondCheckpoint = false;
        CheckPoints.passedFirstCheckpoint = false;
        CheckPoints.forcedSave = true;
        areyousure.SetActive(false);
    }
}
