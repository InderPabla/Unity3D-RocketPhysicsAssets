using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {
	void Update () {

		if((  LevelManager.levelDone || LevelManager.crash==true || CraftScript.craftFuelStatic<=0)&& LevelManager.playing){
			renderer.enabled=true;
			this.name = "Restart";
		}
		else{
			renderer.enabled=false;
			this.name = "RestartStop";
		}
	}
}
