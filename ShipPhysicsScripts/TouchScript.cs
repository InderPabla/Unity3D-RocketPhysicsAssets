using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {

	public static int status = 0; //1=Up, 2=Right, 3=Left, 4=Down

	bool PC =true;
	GUITexture gui;
	RaycastHit hit;
	void Start () {
		gui = guiTexture;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Menu)) {
			Application.Quit();
		}
		
		if(!PC){
			if(Input.touchCount > 0){

				for(int i = 0; i < Input.touchCount; i++){

					Touch touch = Input.GetTouch(i);
					
					if(touch.phase == TouchPhase.Began &&
					   guiTexture.HitTest(touch.position)){
						if(name.Equals("Up")){
							TouchScript.status = 1;
						}
						if(name.Equals("Down")){
							TouchScript.status = 4;
						}
						if(name.Equals("Left")){
							TouchScript.status = 3;
						}
						if(name.Equals("Right")){
							TouchScript.status = 2;
						}
						if(name.Equals("Restart")){
							TouchScript.status = 5;
						}
						if(name.Equals("Pulse")){
							TouchScript.status = 6;
						}
					}
					if(touch.phase == TouchPhase.Ended){
						TouchScript.status=0;
					}
				}
			}
		}//if not PC
		else{
			if (Input.GetMouseButtonDown(0)) {
				if(gui.HitTest( Input.mousePosition)){
					if(this.name.Equals("Left"))
						status=3;
					if(this.name.Equals("Right"))
						status=2;
					if(this.name.Equals("Up")){
						status=1;					
					}
					if(this.name.Equals("Down")){
						status=4;	
					}
				}
				
			}
			
			if(Input.GetMouseButtonUp(0)){
				status=0;
			}
		}//if PC


	}//update method
}
