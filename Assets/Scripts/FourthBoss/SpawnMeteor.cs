using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour {
    public GameObject redMeteor, blueMeteor, greenMeteor, greyMeteor;
    GameObject[] meteorList;
    int numMeteors = 0;
    float randoPos = 0;
    int leftOrRight = 0;
    float period = 0;

    IEnumerator spawnMeteors(int numMeteors0, int leftOrRight0, float randoPos0)
    {
        int whatMeteor = 0;
        if(leftOrRight0 == 1)
        {
            for (int i = 0; i < numMeteors0; i++)
            {
                whatMeteor = Random.Range(0, 6);
                Instantiate(meteorList[whatMeteor], new Vector3(-9, randoPos0, 0), Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(0.50f, 1.00f));
            }
        }
        else
        {
            for (int i = 0; i < numMeteors0; i++)
            {
                whatMeteor = Random.Range(0, 6);
                Instantiate(meteorList[whatMeteor], new Vector3(9, randoPos0, 0), Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(0.50f, 1.00f));
            }
        }
    }

    void Start () {
        meteorList = new GameObject[] { redMeteor, blueMeteor, greenMeteor, greyMeteor, greyMeteor, greyMeteor};
	}

	void Update () {
        period += Time.deltaTime;

        if(period >= 2.5f)
        {
            period = 0;
            randoPos = Random.Range(-3f, 2f);
            leftOrRight = Random.Range(1, 3);
            numMeteors = Random.Range(1, 5);
            StartCoroutine(spawnMeteors(numMeteors, leftOrRight, randoPos));
        }

        if(FrontPowerCore.powerCoreHealth <= 0 && BackPowerCore.powerCoreHealth <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
