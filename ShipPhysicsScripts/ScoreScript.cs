using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	public static float score = 0;
	public static bool state = false;
	TextMesh text;
	Vector3 pos;

	void Start () {
		text = transform.GetComponent<TextMesh>();
		pos = transform.localPosition;
	}
	
	void Update () {
		text.renderer.enabled = state;
		if(LevelManager.levelDone ){
			transform.localPosition = pos;
			transform.localPosition -= new Vector3(0,0.5f,0);
			text.renderer.material.color = Color.green;

			text.text = "Score: "+(int)score 
						+ "\n\nTime: "+(int)LevelManager.time + "s" 
						+ "\n\nStar: "+(int)LevelManager.levelStarScoreLatch;
		}
		else if(LevelManager.crash){
			transform.localPosition = pos;
			transform.localPosition -= new Vector3(0,0.5f,0);
			text.renderer.material.color = Color.red;
			text.text = "Score: "+(int)score 
						+ "\n\nTime: "+(int)LevelManager.time + "s" 
						+ "\n\nStar: 0";
		}
		else{
			transform.localPosition = pos;
			text.renderer.material.color = Color.white;
			text.text = "Score: "+(int)score;
		}
	}
}
