using UnityEngine;
using System.Collections;

public class DynamicObject  {
	public GameObject theObject;
	public GameObject[] theObject2 = new GameObject[5];
	public float vx,vy,va;
	public int state;

	public DynamicObject(GameObject theObject, float va, float vx, float vy, int state, float a){
		this.theObject = theObject;
		this.va = va;
		this.vx = vx;
		this.vy= vy;
		this.state = state;
		this.theObject.transform.eulerAngles = new Vector3(0,0,a);

		if(state==1){
			SpeedScript sc = (SpeedScript)this.theObject.GetComponent(typeof(SpeedScript));
			sc.vy = this.vy;

		}
		else if(state==3){
			ShiftAnimateWaitScript sc = this.theObject.GetComponent<ShiftAnimateWaitScript>();
			sc.wait = this.va;
			sc.speed = this.vy;
		}
	} 

}
