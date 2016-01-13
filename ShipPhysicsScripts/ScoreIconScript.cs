using UnityEngine;
using System.Collections;

public class ScoreIconScript : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		if(other.name.Equals("Craft")){
			ScoreScript.score+=100;
			Destroy(gameObject);
		}
	}
}
