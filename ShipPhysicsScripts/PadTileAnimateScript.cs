using UnityEngine;
using System.Collections;

public class PadTileAnimateScript : MonoBehaviour {
	public float timeWait = 0;
	Color c,c2;
	PadAnimateScript parent;
	
	void Start () {

		parent = transform.parent.GetComponent<PadAnimateScript>();
		if(parent.type == 0){
			c = new Color(120f/255f,255f/255f,120f/255f);
			c2 = Color.green;
		}
		if(parent.type == 1){
			c = new Color(255f/255f,120f/255f,120f/255f);
			c2 = Color.red;
		}
		if(parent.type == 2){
			c = new Color(120f/255f,120f/255f,255f/255f);
			c2 = Color.blue;
		}
		if(parent.type == 3){
			c = new Color(255f/255f,255f/255f,120f/255f);
			c2 = Color.yellow;
		}

		renderer.material.color = c;
	}

	void Update () {
		if(parent.pick==timeWait)
			renderer.material.color = c2;
		else
			renderer.material.color = c;
	}
}
