using UnityEngine;
using System.Collections;

public class ShiftAnimateWaitScript : MonoBehaviour {
	public float wait;
	public float speed;

	void Start () {
		renderer.material.color = Color.grey;
	}
}
