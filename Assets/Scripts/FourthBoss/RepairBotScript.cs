using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBotScript : MonoBehaviour {

    float speed = 3;
    float angleToShip = 0;
    string plate = "BackBasePlate";
    Animator animator;
    bool weldDone = false;
    float period = 0;
    bool isBackPlate = true;
    bool frontRepair = FrontBasePlate.frontRepair;
    bool backRepair = BackBasePlate.backRepair;
    public GameObject endExplode;

    void flyOut()
    {
        float step = Time.deltaTime * speed;
        Vector3 vectorOut = new Vector3(0.5f,8,0) - transform.position;
        angleToShip = Mathf.Atan2(vectorOut.y, vectorOut.x) * Mathf.Rad2Deg;
        transform.position += new Vector3(Mathf.Cos(angleToShip * Mathf.Deg2Rad), Mathf.Sin(angleToShip * Mathf.Deg2Rad), 0) * step;
        transform.rotation = Quaternion.Euler(0, 0, angleToShip + 90);
        if(transform.position.y >= 7)
        {
            Destroy(this.gameObject);
        }
    }

    void angleToPlate(string plateName)
    {
        float step = Time.deltaTime * speed;
        Vector3 vectorToTarget = GameObject.Find(plateName).transform.position - transform.position;
        angleToShip = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.position += new Vector3(Mathf.Cos(angleToShip * Mathf.Deg2Rad), Mathf.Sin(angleToShip * Mathf.Deg2Rad), 0) * step;
        transform.rotation = Quaternion.Euler(0, 0, angleToShip + 90);
    }

    void Start () {
        if(frontRepair == true && backRepair == false)
        {
            isBackPlate = false;
        }
        else if(frontRepair == false && backRepair == true)
        {
            isBackPlate = true;
        }

        animator = GetComponent<Animator>();
        if(isBackPlate)
        {
            plate = "BackBasePlate";
        }
        else
        {
            plate = "FrontBasePlate";
        }
	}

	void Update () {
        if (weldDone == false)
        {
            if (Mathf.Sqrt(Mathf.Pow(transform.position.x - GameObject.Find(plate).transform.position.x, 2) + Mathf.Pow(transform.position.y - GameObject.Find(plate).transform.position.y, 2)) <= 0.1)
            {
                transform.position = GameObject.Find(plate).transform.position;
                animator.SetTrigger("StartWeld");
                period += Time.deltaTime;
                if(period >= 1.5f)
                {
                    period = 0;
                    if(isBackPlate == true)
                    {
                        if(BackBasePlate.numHit == 0)
                        {
                            weldDone = true;
                        }

                        if (BackBasePlate.numHit != 0)
                        {
                            BackBasePlate.numHit--;
                        }
                    }
                    else
                    {
                        if (FrontBasePlate.numHit == 0)
                        {
                            weldDone = true;
                        }

                        if (FrontBasePlate.numHit != 0)
                        {
                            FrontBasePlate.numHit--;
                        }
                    }
                }
                
            }
            else
            {
                angleToPlate(plate);
            }
        }
        else
        {
            animator.SetTrigger("StartFly");
            flyOut();
        }

        if(FrontPowerCore.powerCoreHealth <= 0 && BackPowerCore.powerCoreHealth <= 0)
        {
            Instantiate(endExplode, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
