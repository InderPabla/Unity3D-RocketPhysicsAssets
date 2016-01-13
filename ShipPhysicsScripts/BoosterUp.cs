using UnityEngine;
using System.Collections;

/**
* BoosterUp class, booster animation for when up arrow is pressed
*/
public class BoosterUp : MonoBehaviour {

	int counter =0;

	void Update () {
		if(LevelManager.crash || CraftScript.craftFuelStatic<=0){
			renderer.enabled=false;
		}
		else{
			if(ArrowTouchScript.status == 1 || ArrowTouchScript.status == 4){
				counter++;
				if(counter>70){
					particleEmitter.rndVelocity = new Vector3(0,0.3f,0);
				}
				else if(counter>30){
					particleEmitter.localVelocity = new Vector3(-0.5f,0,0);
					particleEmitter.maxSize=0.5f;
				}
				else{
					particleEmitter.maxSize=0.2f;
					particleEmitter.localVelocity = new Vector3(-0.1f,0,0);
					renderer.enabled=true;
				}
				
			}

			else {
				counter=0;
				particleEmitter.minSize=0.2f;
				particleEmitter.maxSize=0.2f;
				particleEmitter.rndVelocity = new Vector3(0,0,0);
				particleEmitter.localVelocity = new Vector3(0,0,0);
				renderer.enabled=false;
			}
		}
	}
}
