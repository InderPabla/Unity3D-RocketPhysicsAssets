using UnityEngine;
using System.Collections;

public class ModeChange : MonoBehaviour {
	bool state = false;
	TextMesh text;

	void Start () {
		text = transform.GetComponent<TextMesh>();
		state = !CraftScript.stabilize;
	}

	void Update () {
		if(StartButtonScript.status==-9){
			StartButtonScript.status = 0;
			state = !state;
			CraftScript.stabilize = !state;
		}

		if(state){
			text.text = "Hard Mode : ON";
		}
		else{
			text.text = "Hard Mode : OFF";
		}
	}
}
