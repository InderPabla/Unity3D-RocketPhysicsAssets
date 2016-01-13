using UnityEngine;
using System.Collections;

public class BrokenTopBooster : MonoBehaviour {
	float v = 1f;
	
	void Update () {
		rigidbody.angularVelocity+= new Vector3(0,0,v*Time.deltaTime);
	}
}
