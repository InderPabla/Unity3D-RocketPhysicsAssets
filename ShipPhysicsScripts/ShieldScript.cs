using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

	public static bool state = false;
	public static int numberOfForceFields = 0;
	TextMesh child;
	bool got = false;
	void Start () {
		
	}
	
	void Update () {
		if(!got){
			if(transform.GetComponentInChildren<TextMesh>()!=null){
				child = transform.GetComponentInChildren<TextMesh>();
				got = true;
			}
		}
		collider.enabled = state;
		renderer.enabled = state;
		if(got){
			child.renderer.enabled = state;
		}
		child.text = numberOfForceFields+"";

		if(numberOfForceFields <= 0){
			numberOfForceFields = 0;
			renderer.material.color = Color.gray;
		}
		else{
			renderer.material.color = Color.white;
		}
	}
}
