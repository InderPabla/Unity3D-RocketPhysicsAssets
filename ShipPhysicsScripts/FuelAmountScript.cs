using UnityEngine;
using System.Collections;

public class FuelAmountScript : MonoBehaviour {
	Vector3 pos;
	TextMesh text;
	float time = 0;
	bool blink = false;
	bool setColor = false;
	void Start () {
		pos = transform.localPosition;
		text = transform.GetComponent<TextMesh>();
	}
	
	void Update () {
		if(LevelManager.playing){
			if(!setColor){
				text.color = Color.white;
				setColor = true;
			}
			if(LevelManager.crash && CraftScript.craftFuelStatic!=0){
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
			text.text = "Fuel: "+Mathf.Round(CraftScript.craftFuelStatic*10)/10+"%";
			transform.localPosition = pos;
			text.renderer.enabled = true;
		}
		else{
			setColor = false;
			text.renderer.enabled = false;
		}
	}
}
