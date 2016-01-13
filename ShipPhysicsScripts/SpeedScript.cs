using UnityEngine;
using System.Collections;

public class SpeedScript : MonoBehaviour {
	public float vx,vy,va;
	public Color c = Color.green;

	public bool statePush = true;


	void Start () {
		renderer.material.color = c;
	}

	void OnTriggerEnter(Collider other){
		if(!statePush){
			other.rigidbody.velocity = Vector3.zero;
			other.rigidbody.velocity += transform.up*vy*Time.deltaTime;
			other.rigidbody.velocity += transform.right*vx*Time.deltaTime;
		}
	}

	void OnTriggerStay(Collider other){
		if(statePush){
			other.rigidbody.velocity += transform.up*vy*Time.deltaTime;
			other.rigidbody.velocity += transform.right*vx*Time.deltaTime;
		}
	}
}
