using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShipDestroyed : MonoBehaviour {
    bool crashed = false;
    public GameObject destroyedExplosion;
    bool hasExploded = false;

    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }

    void moveToSide()
    {
        float step = 3 * Time.deltaTime;
        transform.position += Vector3.right * step;
    }

	void Start(){
        CheckPoints.passedSecondCheckpoint = true;
    }
	
	void Update(){
        if (transform.position.x < 7)
        {
            moveToSide();
        }
        else if (transform.position.x >= 7 && hasExploded == false)
        {
            Instantiate(destroyedExplosion, transform.position, Quaternion.identity);
            hasExploded = true;
            if (GameObject.Find("ShipIsDestroyedExplosion(Clone)"))
            {
                StartCoroutine(delayDestroy());
            }
        }
    }
}
