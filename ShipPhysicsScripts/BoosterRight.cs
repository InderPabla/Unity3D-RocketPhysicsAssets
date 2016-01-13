using UnityEngine;
using System.Collections;

/**
* BoosterRight class, craft right booster animation
*/
public class BoosterRight : MonoBehaviour {
	int counter =0;
	void Update () {
		if(LevelManager.crash || CraftScript.craftFuelStatic<=0){
			renderer.enabled=false;
		}
		else{
			if(ArrowTouchScript.status == 2){
				counter++;
				if(counter>10){
					
					particleEmitter.localVelocity = new Vector3(0,0.4f,0);
					particleEmitter.maxSize=0.15f;
					particleEmitter.minSize=0.15f;
				}
				else{
					particleEmitter.rndVelocity = new Vector3(0.2f,0,0);
					particleEmitter.localVelocity = new Vector3(0,0.1f,0);
					particleEmitter.minSize=0.07f;
					particleEmitter.maxSize=0.07f;
				}
				renderer.enabled=true ;
			}
			else if(ArrowTouchScript.status == 4){
				counter++;
				if(counter>10){
					
					particleEmitter.localVelocity = new Vector3(0.4f,0,0);
					particleEmitter.maxSize=0.15f;
					particleEmitter.minSize=0.15f;
				}
				else{
					particleEmitter.rndVelocity = new Vector3(0,0.2f,0);
					particleEmitter.localVelocity = new Vector3(0.1f,0,0);
					particleEmitter.minSize=0.07f;
					particleEmitter.maxSize=0.07f;
				}
				renderer.enabled=true ;
			}
			else {
				
				counter =0;
				renderer.enabled=false;
				particleEmitter.rndVelocity = new Vector3(0,0,0);
				particleEmitter.localVelocity = new Vector3(0,0,0);
			}
		}
	}//update method
}
