using UnityEngine;
using System.Collections;

public class FuelBarScript : MonoBehaviour {
	Color fuelColor = Color.green;
	Vector3 topLeft;
	Vector3 normScale;

	void Start () {
		normScale = transform.localScale;
		topLeft = transform.localPosition;
		topLeft.y+=transform.localScale.y/2f;
	}
	
	void Update () {
		if(LevelManager.playing){
			float r = (100f - CraftScript.craftFuelStatic) / 50f;
			float g = CraftScript.craftFuelStatic / 100f;
			fuelColor = new Color (r,g,0);
			renderer.material.color = fuelColor;

			transform.localScale = new Vector3(transform.localScale.x,  normScale.y*(CraftScript.craftFuelStatic/100f)  ,0.06f);
			transform.localPosition = new Vector3(topLeft.x,topLeft.y,topLeft.z);
			transform.localPosition += new Vector3(0,-transform.localScale.y/2f,0);
			renderer.enabled = true;
		}
		else{
			renderer.enabled = false;
		}
	}
}
