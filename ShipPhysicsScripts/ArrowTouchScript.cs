using UnityEngine;
using System.Collections;

/**
* ArrowTouchScript class, get touch information based on arrows on screen
*/
public class ArrowTouchScript : MonoBehaviour {
	public static int status;
	Ray ray;
	RaycastHit hit;
	Vector3 normCollider, bigCollider;
	Vector3 normScale, bigScale;
	bool latch = false;

	BoxCollider boxCollider;

	Color normColor,bigColor;
	SpriteRenderer sR;
	void Start () {
		boxCollider = collider.GetComponent<BoxCollider>();

		normCollider = boxCollider.size;
		bigCollider = boxCollider.size*3f;

		normScale = transform.localScale;
		bigScale = transform.localScale*1.1f;

		sR = transform.GetComponent<SpriteRenderer>();
		normColor = sR.color;
		bigColor = Color.red;
	}
	
	void Update () {
		if(LevelManager.playing && !LevelManager.levelDone && !LevelManager.crash){
			if(latch){ 
				renderer.enabled = true;
				collider.enabled = true;
				latch = false;
				boxCollider.size = normCollider;
				sR.color= normColor;
			}
			if(Camera.main!=null)
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if (Input.GetMouseButtonDown (0))  {
				if (Physics.Raycast (ray, out hit, 100) ) {
					if(!hit.transform.name.Equals(this.name)){
						collider.enabled = false;
					}
					else{
						boxCollider.size = bigCollider;
						transform.localScale = bigScale ;

						sR.color= bigColor;
					}
					if(hit.transform.name.Equals("Up")){
						ArrowTouchScript.status = 1;
					}
					else if(hit.transform.name.Equals("Left")){
						ArrowTouchScript.status = 3;
					}
					else if(hit.transform.name.Equals("Right")){
						ArrowTouchScript.status = 2;
					}
					else if(hit.transform.name.Equals("Down")){
						ArrowTouchScript.status = 4;
					}



				}//a hit detected on mouse up
			}

			if(Input.GetMouseButtonUp (0)){
				ArrowTouchScript.status =0;
				boxCollider.size = normCollider;
				transform.localScale = normScale;
				sR.color= normColor;
				collider.enabled = true;
			}
		}// if playing
		else{

			ArrowTouchScript.status =0;
			if(!latch){
				renderer.enabled = false;
				collider.enabled = false;
				sR.color= normColor;
				boxCollider.size = normCollider;
				latch = true;
			}
		}
	}
}
