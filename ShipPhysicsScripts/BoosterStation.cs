using UnityEngine;
using System.Collections;

/**
* BoosterStation class, booster space station animation
*/
public class BoosterStation : MonoBehaviour {

	public int counter=0;
	int counter2=20;
	bool s=true;
	Vector3 local;
	void Start () {
		local = particleEmitter.localVelocity;
	}

	void Update () {
		counter++;
		if(counter==counter2){
			counter2= counter + 50;
			if(s==false){
				particleEmitter.localVelocity = local;
			}
			else if(s==true){
				particleEmitter.localVelocity = Vector3.zero;
			}

			s=!s;
			renderer.enabled = s;

		}
	}
}
