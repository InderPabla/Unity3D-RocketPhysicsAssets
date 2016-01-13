using UnityEngine;
using System.Collections;

public class BrokenBackBooster : MonoBehaviour {
	float v = 2f;
	float time = 0;
	float delay = 3f;
	void Start () {
		
	}

	void Update () {
		if (this.name.Contains("Back2")){
			if(CraftScript.craftFuelStatic>0){
				rigidbody.velocity+=transform.right*v*Time.deltaTime;
			}
		}
		else{
			if(CraftScript.craftFuelStatic<=1){

				if(time>=delay){
					renderer.enabled = false;
				}
				else{
					time += Time.deltaTime;
				}
			}
			else if(CraftScript.craftFuelStatic<=10){
				particleEmitter.minEnergy = 0.25f;
				particleEmitter.maxEnergy = 0.25f;
				particleEmitter.maxEmission = 75;
				particleEmitter.minEmission = 75;
			}
			else if(CraftScript.craftFuelStatic<=20){
				particleEmitter.minEnergy = 0.5f;
				particleEmitter.maxEnergy = 0.5f;
				particleEmitter.maxEmission = 100;
				particleEmitter.minEmission = 100;
			}
			else if(CraftScript.craftFuelStatic<=35){
				particleEmitter.minEnergy = 0.75f;
				particleEmitter.maxEnergy = 0.75f;
				particleEmitter.maxEmission = 200;
				particleEmitter.minEmission = 200;
			}
		}
	}
}
