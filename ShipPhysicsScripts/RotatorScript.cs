using UnityEngine;
using System.Collections;

public class RotatorScript : MonoBehaviour {
	public float va;
	public Color c = Color.red;
	Vector3 pos;

	public bool applyColor = true;

	void Start () {
		if(applyColor)
			renderer.material.color = c;
	}
	
	void Update () {
		transform.eulerAngles += new Vector3(0,0,va*Time.deltaTime);
	}
}
