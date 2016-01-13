using UnityEngine;
using System.Collections;

public class ShiftAnimateScript : MonoBehaviour {
	Transform child;
	Vector3 pos;

	bool toggle = false;
	public float adder = 0;

	public float waitDelay;
	public float speed;
	public bool start = false;

	Transform parent;
	void Start () {
		ShiftAnimateWaitScript sc= transform.parent.GetComponent<ShiftAnimateWaitScript>();
		waitDelay = sc.wait;
		speed = sc.speed;
		parent = transform.parent;
	}

	void Update () {
		if(start){
			Vector3 v;
			if(!toggle){
				v = transform.localPosition;
				v.x += -speed*Time.deltaTime;
				transform.localPosition = v;
				if(transform.localPosition.x+transform.localScale.x/2f<0)
					toggle = true;

			}
			else{
				v = transform.localPosition;
				v.x += speed*Time.deltaTime;
				transform.localPosition = v;	
				if(transform.localPosition.x-transform.localScale.x/2f>0)
					toggle = false;
			}
		}
		else{
			if(adder>=waitDelay){
				adder = 0f;
				start = true;
			}
		}
		adder += Time.deltaTime;
	}
}
