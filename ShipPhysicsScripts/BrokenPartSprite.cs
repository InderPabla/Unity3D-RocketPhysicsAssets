using UnityEngine;
using System.Collections;

public class BrokenPartSprite : MonoBehaviour {
	public float z = 0;

	void Start () {
	
	}
	
	void Update () {
		set2DBehaviours();	
	}
	void set2DBehaviours(){
		Vector3 craftS = transform.position;
		craftS.z =z;
		transform.position = craftS;
		craftS =  transform.eulerAngles;
		craftS.x =0;
		craftS.y =0;
		transform.eulerAngles = craftS;
	}
	
}
