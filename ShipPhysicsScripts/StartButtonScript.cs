using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {
	RaycastHit hit;
	Vector3 localScale;
	public static int status;
	Ray ray;
	void Start () {
		localScale = transform.localScale;
	}
	

	void Update () {
		StartButtonScript.status =0;
		if(Camera.main!=null)
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Input.GetMouseButtonUp (0))  {
			if (Physics.Raycast (ray, out hit, 100) ) {
				if(hit.transform.name.Equals("Play")){
					//Debug.Log("Play");
					StartButtonScript.status = -1;
				}
				else if(hit.transform.name.Equals("Back")){
					//Debug.Log("Back");
					StartButtonScript.status = -2;	
				}
				else if(hit.transform.name.Equals("Reset")){
					//Debug.Log("Reset");
					StartButtonScript.status = -3;
				}
				else if(hit.transform.name.Equals("Next")){
					//Debug.Log("Next");
					StartButtonScript.status = -4;
				}
				else if(hit.transform.name.Equals("Laser")){
					//Debug.Log("Laser");
					StartButtonScript.status = -5;
				}
				else if(hit.transform.name.Equals("Shield")){
					//Debug.Log("Shield");
					StartButtonScript.status = -6;
				}
				else if(hit.transform.name.Equals("Restart")){
					//Debug.Log("Restart");
					StartButtonScript.status = -7;
				}
				else if(hit.transform.name.Equals("NextLevel")){
					//Debug.Log("NextLevel");
					StartButtonScript.status = -8;
				}
				else if(hit.transform.name.Equals("HardMode")){
					//Debug.Log("HardMode");
					StartButtonScript.status = -9;
				}
				else{
					int num1;
					bool res = int.TryParse(hit.transform.name, out num1);
					if (res == false)
						StartButtonScript.status=0;
					else
						StartButtonScript.status = num1;	

				}
			}//a hit detected on mouse up

			transform.localScale = localScale;
		}
		else if (Input.GetMouseButtonDown (0))  {
			if (Physics.Raycast (ray, out hit, 100) && hit.transform.name.Equals("Play")) {
				hit.transform.transform.localScale = new Vector3(0.5f,0.5f,0.2f);
			}
		}
	}
}
