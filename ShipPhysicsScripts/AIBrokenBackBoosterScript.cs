using UnityEngine;
using System.Collections;

/**
* AIBrokenBackBoosterScript class, back part of AI craft's animation after crash
*/
public class AIBrokenBackBoosterScript : MonoBehaviour {
	float v = 2f;
	float time = 0;
	float delay = 3f;
	float fuel = 100;
	string theName;
	void Start () {
		theName = transform.parent.name;
	}

	void Update () {
		if(!theName.Contains("Back2Start") && !theName.Contains("StartScreen"))
			fuel -= Time.deltaTime*25f;
		if (this.name.Contains("Back2")){
			if(fuel>0){
				rigidbody.velocity+=transform.right*v*Time.deltaTime;
			}
		}
		else{
			if(fuel<=1){
				
				if(time>=delay){
					renderer.enabled = false;
				}
				else{
					time += Time.deltaTime;
				}
			}
			else if(fuel<=10){
				particleEmitter.minEnergy = 0.25f;
				particleEmitter.maxEnergy = 0.25f;
				particleEmitter.maxEmission = 75;
				particleEmitter.minEmission = 75;
			}
			else if(fuel<=20){
				particleEmitter.minEnergy = 0.5f;
				particleEmitter.maxEnergy = 0.5f;
				particleEmitter.maxEmission = 100;
				particleEmitter.minEmission = 100;
			}
			else if(fuel<=35){
				particleEmitter.minEnergy = 0.75f;
				particleEmitter.maxEnergy = 0.75f;
				particleEmitter.maxEmission = 200;
				particleEmitter.minEmission = 200;
			}
		}
	}
}
