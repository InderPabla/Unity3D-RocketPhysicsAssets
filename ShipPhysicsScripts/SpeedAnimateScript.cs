using UnityEngine;
using System.Collections;

public class SpeedAnimateScript : MonoBehaviour {
	Transform par;
	void Start () { 
		rigidbody.velocity = transform.up*3f;
		par = transform.parent;
		Color c = transform.gameObject.renderer.material.color;
		renderer.material.color = c;
	}
	
	void Update () {

		Vector3 newPos;
		if(transform.localPosition.y-transform.localScale.y/2 >= 0.5f ){
			newPos = transform.localPosition;
			newPos.y = -0.5f+transform.localScale.y/2;
			transform.localPosition = newPos;
		}

	}
}
