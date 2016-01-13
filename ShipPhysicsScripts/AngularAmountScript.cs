using UnityEngine;
using System.Collections;

/**
* AngularAmountScript class, set angular momentum text
*/
public class AngularAmountScript : MonoBehaviour {

	Vector3 pos;
	TextMesh text;
	float time = 0;
	bool blink = false;
	void Start () {
		pos = transform.localPosition;
		text = transform.GetComponent<TextMesh>();
	}
	
	
	void Update () {
		if(LevelManager.playing){
			if(LevelManager.crash){
				text.text = "Angular: ERROR";

				time += Time.deltaTime;
				if(time>=0.25f){
					blink=!blink;
					time = 0;
				}
				if(!blink){
					text.color = Color.red;
				}
				else{
					text.color = Color.white;
				}
			}
			else{
				text.text = "Angular: "+Mathf.Round(LevelManager.craftAngSpeed*10f*9.1f)/10+"m/s";
				text.color = Color.white;

			}
			
			transform.localPosition = pos;
			text.renderer.enabled = true;
		}
		else{
			text.renderer.enabled = false;
		}
	}
}
