using UnityEngine;
using System.Collections;

public class FuelPadScript : MonoBehaviour {
	void OnTriggerStay(Collider other){
		if(other.name.Equals("Craft")){
			CraftScript.startFuel = true;
			CraftScript.craftFuelStatic+=0.1f;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.name.Equals("Craft")){
			CraftScript.startFuel = false;
		}
	}
}
