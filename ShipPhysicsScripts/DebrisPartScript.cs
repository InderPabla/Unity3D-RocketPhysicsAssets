using UnityEngine;
using System.Collections;

public class DebrisPartScript : MonoBehaviour {
	public Vector3 iniVelo;
	public Vector3 iniAngVelo;

	int counter = 0;
	public int max;

	public GameObject dustPrefab;
	GameObject dust;
	public bool initialStateAdd = false;

	void Start () {
		if(initialStateAdd){
			rigidbody.velocity = iniVelo;
			rigidbody.angularVelocity = iniAngVelo;
		}
	}
	
	void Update () {
		set2DBehaviours();
	}
	
	void set2DBehaviours(){
		Vector3 laserS = transform.position;
		laserS.z =0;
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
				Destroy(gameObject);
			}
		}
	}
}
