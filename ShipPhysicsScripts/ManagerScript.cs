using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ManagerScript : MonoBehaviour {

	CraftScript craft;
	public LevelManager levelManager;
	
	public GameObject mainCamera;
	GameObject camera;  //needs to be public so GameScript can acess

	public GameObject background;
	GameObject tempBackground;  //needs to be public so GameScript can acess

	public GameObject detector;
	public GameObject[] levels = new GameObject[18];


	public GameObject[] brokenCraftObject = new GameObject[6];		


	public GameObject explosionObject;
		   


		   

	Color fuelColor;

	float cameraZ = -100;

	public GameObject laserPrefab;
	public GameObject forceFieldPrefab;

	void Start () {
		camera = Instantiate(mainCamera) as GameObject;
		tempBackground = Instantiate(background) as GameObject;
		levelManager = new LevelManager(levels,transform,rigidbody,brokenCraftObject,explosionObject,laserPrefab,forceFieldPrefab);
		Destroy(GameObject.Find("New Game Object"));
	}
	

	void Update () {
		updateVisual();
		if(levelManager.craft.craftFuel>0 || CraftScript.startFuel){
			levelManager.craft.UpdateCraft();//Move craft and set craft behaviour 
		}

		levelManager.updateLevelPhysics();
	}//update method



	void OnCollisionEnter(Collision other){
		levelManager.collision(other);
	}//collision



	void updateVisual(){
		if(!LevelManager.crash){
			Vector3 cameraPos = transform.position;
			cameraPos.z=cameraZ;
			camera.transform.position = cameraPos;
			camera.camera.orthographicSize=5f;
			cameraPos.z = 1;
			tempBackground.transform.position = cameraPos;

			camera.transform.eulerAngles = new Vector3(0,0,0);

		}
		else{
			Vector3 cameraPos = levelManager.tempO[levelManager.crashViewIndex].transform.position;
			cameraPos.z=cameraZ;
			camera.transform.position = cameraPos;
			cameraPos.z=1f;
			tempBackground.transform.position = cameraPos;
		}
	}

	public void destroy(){
		Destroy(this.camera);
		Destroy(this.tempBackground);
	}
}
