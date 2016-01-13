using UnityEngine;
using System.Collections;

public class LaserShooterScript : MonoBehaviour {
	public GameObject laserPrefab;
	GameObject laser;

	public float delay;
	float adder=0;
	float vy = 5f;

	public Color c = Color.yellow;
	public Color lc = Color.red;
	public float newTime = 3f;

	public bool startScreen = false;

	void Start () {
		renderer.material.color = c;
	}
	
	void Update () {

		if(adder>=delay){
			Vector3 tr;
			laser = GameObject.Instantiate(laserPrefab,laserPrefab.transform.position,transform.rotation) as GameObject;
			laser.transform.position = transform.position;
			laser.transform.eulerAngles += new Vector3(0,0,90);
			laser.transform.Translate(transform.localScale.x+laser.transform.localScale.x,0,0,Space.Self);
			laser.rigidbody.velocity = transform.up*vy;
			laser.rigidbody.mass = 0.1f;
			adder = 0;
			if(!startScreen)
				laser.transform.parent = GameObject.Find("Level").transform;
			else{
				laser.transform.parent = GameObject.Find("StartScreen").transform;
				laser.GetComponent<LaserBulletScript>().z = -0.5f;
			}

			LaserBulletScript lbs = laser.GetComponent<LaserBulletScript>();
			lbs.changeTimeOut(newTime);
			lbs.destoryOnImpact = false;
			laser.renderer.material.color = lc;
		}

		adder+=Time.deltaTime;
	}
}
