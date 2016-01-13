using UnityEngine;
using System.Collections;

public class EndPadScript : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		if(other.name.Equals("Craft")){
			ManagerScript ms = other.GetComponent<ManagerScript>();
			ms.levelManager.endPadCollided();
		}
	}
}
