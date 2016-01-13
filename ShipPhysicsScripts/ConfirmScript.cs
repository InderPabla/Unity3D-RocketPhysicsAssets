using UnityEngine;
using System.Collections;

public class ConfirmScript : MonoBehaviour {

	GetConfirmScript yesS,noS;

	public static int confimed = 0;
	void Start () {
		Transform trans = this.transform.FindChild("TransparentScreen");
		Color c = trans.renderer.material.color;
		c.a = 0.75f;
		trans.renderer.material.color = c;

		Transform yes = this.transform.FindChild("Yes");
		Transform no = this.transform.FindChild("No");
		yesS = yes.GetComponentInChildren<GetConfirmScript>();
		noS = no.GetComponentInChildren<GetConfirmScript>();
	}

	void Update () {
		if(yesS.hitTest == yesS.yesHit){
			confimed = yesS.hitTest;
		}
		if(noS.hitTest == noS.noHit){
			confimed = noS.hitTest;
		}
	}
}
