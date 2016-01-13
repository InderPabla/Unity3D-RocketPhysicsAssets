using UnityEngine;
using System.Collections;

public class PadAnimateScript : MonoBehaviour {
	float adder = 0;
	float delay = 0.15f;
	public int pick = 0;
	float animateTiles;

	public int type;
	void Start () {
		animateTiles = 8;
		pick = (int)animateTiles/2;

		if(type == 0)
			transform.renderer.material.color = new Color(170f/255f,255f/255f,170f/255f);
		if(type == 1)
			transform.renderer.material.color = new Color(255f/255f,170f/255f,170f/255f);
		if(type == 2)
			transform.renderer.material.color = new Color(170f/255f,170f/255f,255f/255f);
		if(type == 3)
			transform.renderer.material.color = new Color(255f/255f,2550f/255f,170f/255f);
		transform.position+=new Vector3(0,0,0.0002f);

		
	}

	void Update () {
		
		if(adder<=0){
			adder = delay;
			pick --;
			if(pick <= 0)
				pick = (int)animateTiles/2;
		}
		adder -= Time.deltaTime;
	}
}
