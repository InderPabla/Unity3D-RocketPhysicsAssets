using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
	public static bool state = false;
	
	void Update () {
		collider.enabled = state;
		renderer.enabled = state;
	}
}
