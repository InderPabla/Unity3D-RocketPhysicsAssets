using UnityEngine;
using System.Collections;

public class InvisibleScript : MonoBehaviour {
	int counter = 0;
	Vector3 pos;

	void Start () {
		pos = transform.position;
	}
	
	void Update () {
		counter--;
		if(counter<=0){
			counter = 0;
			renderer.enabled = false;
		}
		transform.position = pos;
		transform.eulerAngles = Vector3.zero;
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}

	void OnCollisionEnter(Collision other){
		if(!other.collider.name.Contains("craf")){
			counter = 20;
			renderer.enabled = true;
		}
	}//collision

	void OnCollisionStay(Collision other){
		if(!other.collider.name.Contains("craf")){
			counter = 20;
			renderer.enabled = true;
		}
	}
}
