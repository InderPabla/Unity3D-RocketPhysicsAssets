using UnityEngine;
using System.Collections;

public class GetConfirmScript : MonoBehaviour {
	RaycastHit hit;
	public int hitTest =0;
	public int yesHit = 1;
	public int noHit = 2;
	void Start () {
	
	}
	
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if (Input.GetMouseButtonUp (0))  {
			if (Physics.Raycast (ray, out hit, 100) ) {
				if(hit.transform.name.Equals("Yes")){
					hitTest = yesHit;
				}
				else if(hit.transform.name.Equals("No")){
					hitTest = noHit;
				}
			}
		}
	}//update method
}
