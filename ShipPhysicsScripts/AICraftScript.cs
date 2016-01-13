using UnityEngine;
using System.Collections;

/**
* AICraftScript class, AICraft physics
*/
public class AICraftScript : MonoBehaviour {
	public Vector3 iniVelo;
	public Vector3 iniAngVelo;
	Vector3 v;

	float velocityThreshold = 1f;
	float angularVelocityThreshold = 1f;
	public Color c = Color.green;

	public GameObject explosionObject;
	GameObject tempExplosion;
	
	public GameObject[] brokenCraftObject = new GameObject[8];
	GameObject[] tempO = new GameObject[8];
	int once = 0;

	public bool startScreen = false;
	void Start () {
		rigidbody.velocity = transform.right*iniVelo.x;
		rigidbody.angularVelocity = iniAngVelo;
		renderer.material.color = c;
	}

	void Update () {
		v = rigidbody.velocity;
	}

	void OnCollisionEnter(Collision other){
		Vector3 vN = new Vector3();
		Vector3 vN2 = new Vector3();
		if(other.rigidbody!=null){
			vN = v-other.rigidbody.velocity;
			vN2 = other.rigidbody.angularVelocity;
		}
		else{
			vN = v-Vector3.zero;
			vN2 = Vector3.zero;
		}

		if((vN.magnitude>velocityThreshold|| vN2.magnitude>angularVelocityThreshold  || other.collider.name.Contains("Dead")) && !other.collider.name.Contains("Part")){
			once ++;
			if(once==1){
				Vector3 tr;
				
				Vector3 vel = rigidbody.velocity;  
				Vector3 rot = rigidbody.angularVelocity;  


				for(int i=0;i<brokenCraftObject.Length;i++){
					tempO[i] = Instantiate(brokenCraftObject[i],brokenCraftObject[i].transform.position,transform.rotation)as GameObject;
					tr = tempO[i].transform.position;
					tempO[i].transform.position = transform.position;
					tempO[i].transform.Translate(tr,Space.Self);
					Rigidbody theR = tempO[i].rigidbody;
					theR.useGravity = false;
					
					theR.velocity = vel;
					theR.angularVelocity = rot;
					if(tempO[i].name.Contains("Back1")){
						tempO[i].transform.eulerAngles+=new Vector3(0,0,45);
					}

					if(!startScreen)
						tempO[i].transform.parent = GameObject.Find("Level").transform;
					else{
						tempO[i].transform.parent = GameObject.Find("StartScreen").transform;
						tempO[i].GetComponent<BrokenPartSprite>().z = -0.5f;
						if(tempO[i].name.Contains("Back2")){

							tempO[i].name = "Back2Start";
						}
					}
					tempO[i].renderer.material.color = c;
				} //break craft
			}// once
				Destroy(gameObject);
			
		}
	}
}
