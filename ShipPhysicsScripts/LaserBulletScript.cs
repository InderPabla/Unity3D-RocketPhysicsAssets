using UnityEngine;
using System.Collections;

public class LaserBulletScript : MonoBehaviour {
	float timeOut = 7.0f;
	public GameObject sparkPrefab;
	GameObject spark;
	public bool destoryOnImpact = true;
	bool diff = false;

	int chance = 0;
	int audioChance = 0;
	public float z = 0;

	void Start () {
		chance = Random.Range(1,5);
		audioChance = Random.Range(1,3);
	}

	public void changeTimeOut(float time){
		diff = true;
		Invoke ("DestroyNowDiff", time);
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
		if(chance == 1){
			spark = Instantiate(sparkPrefab,sparkPrefab.transform.position,transform.rotation) as GameObject;
			Vector3 tr;
			tr = spark.transform.position;
			spark.transform.position = transform.position;
			spark.transform.Translate(tr,Space.Self);
			spark.transform.eulerAngles += new Vector3(0,0,Random.Range(0f,180f));

			if(GameObject.Find("Level")!=null)
				spark.transform.parent = GameObject.Find("Level").transform;
			else if(GameObject.Find("StartScreen")!=null)
				spark.transform.parent = GameObject.Find("StartScreen").transform;
		}


		if(destoryOnImpact || other.collider.name.Contains("Star")|| other.collider.name.Contains("Laser"))
			DestroyObject (gameObject);


	}

	void DestroyNow (){
		if(!diff)
			DestroyObject (gameObject);
	}

	void DestroyNowDiff (){
		
		DestroyObject (gameObject);
	}


}
