using UnityEngine;
using System.Collections;

public class NextLevelScript : MonoBehaviour {
	public static bool state = false;

	void Update () {
		if((  LevelManager.levelDone || LevelManager.crash==true || CraftScript.craftFuelStatic<=0)&& LevelManager.playing){
			renderer.enabled=true;
			collider.enabled = true;
		}
		else{
			renderer.enabled=false;
			collider.enabled = false;
		}
	
	}
}
