using UnityEngine;
using System.Collections;

public class DebrisScript : MonoBehaviour {
	public Vector3 iniVelo;
	public Vector3 iniAngVelo;
	int counter = 0;
	public int max;

	public GameObject[] debriParts = new GameObject[6];
	GameObject debris;

	public GameObject dustPrefab;
	GameObject dust;
	public float z = 0;

	void Start () {
		rigidbody.velocity = iniVelo;
		rigidbody.angularVelocity = iniAngVelo;
	}
	
	void Update () {
		set2DBehaviours();
	}

	void set2DBehaviours(){
		Vector3 laserS = transform.position;
		laserS.z =z;
		transform.position = laserS;
		laserS = transform.eulerAngles;
		laserS.x =0;
		laserS.y =0;
		transform.eulerAngles = laserS;
		
		laserS = rigidbody.velocity;
		laserS.z =0;
		rigidbody.velocity = laserS;
		
		laserS = rigidbody.angularVelocity;
		laserS.x =0;
		laserS.y =0;
		rigidbody.angularVelocity = laserS;
	}

	void OnCollisionEnter(Collision other){
		if(other.collider.name.Equals("Laser")){
			counter++;
			if(counter >= max){
				dust  = GameObject.Instantiate(dustPrefab,transform.position,transform.rotation) as GameObject;
				dust.transform.parent = GameObject.Find("Level").transform;
				Vector3 tr;
				for(int i=0;i<debriParts.Length;i++){
					debris = GameObject.Instantiate(debriParts[i],debriParts[i].transform.position,transform.rotation)as GameObject;
					tr = debris.transform.position;
					debris.transform.position = transform.position;
					debris.transform.Translate(tr,Space.Self);
					debris.transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,1);
					debris.collider.name = "Debris";
					debris.rigidbody.useGravity=false;

					debris.rigidbody.velocity = rigidbody.velocity;
					debris.rigidbody.angularVelocity = rigidbody.angularVelocity;
					debris.transform.parent = GameObject.Find("Level").transform;
				} //break Debris into smaller Debris
				counter = 0;
				Destroy(gameObject);
			}
		}
	}
}
