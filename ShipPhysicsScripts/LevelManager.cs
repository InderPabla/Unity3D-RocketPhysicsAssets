using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager  {


	public GameObject tempLevel;

	public GameObject singleTemp = new GameObject();


	public static int staticLevel = 1;
	public int level = 9;

	GameObject[] levels;

	Rigidbody craftRigidbody;
	Transform craftTransform;

	public bool gravityLatch = false;
	public float explosionForce;
	public float velocityThreshold;
	public float angularVelocityThreshold;
	public Vector3 gravityPos;
	public float accleration;
	public bool crashed=false;
	
	public CraftScript craft;
	float val,val2;
	Vector3 v,v2;
	public static bool crash;

	public GameObject[] brokenCraftObject;
	public GameObject[] tempO = new GameObject[8];


	public GameObject explosionObject;
	GameObject tempExplosion;

	float dvx, dvy;

	bool touching=false;
	bool touchLatch=false;
	string touchString;

	public static float time;
	public static int levelStarScore = 0;
	public static int levelStarScoreLatch = 0;
	public int preLevel = 0;
	public float preTime = 0;

	public static bool next = false;
	public int crashViewIndex = 2; 

	GameObject laserPrefab;
	GameObject laser;

	GameObject forceFieldPrefab;
	GameObject forceField;
							// 1   2   3    4    5    6    7    8    9    10   11   12   13  14   15   16    17    18
	float[] initialScores   = {50, 100,200, 200, 100, 200, 225, 150, 350, 350, 500, 300, 75, 350, 550, 450,  1500, 600};
	float[] threeStarScores = {18, 30, 220, 158, 38,  130, 44,  25,  100, 145, 175, 110, 25, 60,  200, 125,  450,  200};
	float[] twoStarScores   = {10, 20, 210, 150, 30,  120, 34,  15,  90,  130, 150, 80,  15, 50,  150, 85,   250,  100};
	public int levelScore = 0;
	public static bool playing;

	public static bool levelDone = false;

	public static float craftSpeed,craftAngSpeed;

	public LevelManager(GameObject[] theLevels, Transform t, Rigidbody r,GameObject[] tC, GameObject eX, GameObject laserPrebab, GameObject forceFieldPrefab){

		brokenCraftObject = tC;

		craft = new CraftScript(r,t);
		levels = theLevels;
	
		craftTransform = t;
		craftRigidbody = r;
		explosionObject = eX;

		this.laserPrefab = laserPrebab;
		this.forceFieldPrefab = forceFieldPrefab;


		level = staticLevel;
		levelLoader();
		craftTransform.name = "Craft";
		playing = true;


	}

	
	public void updateLevelPhysics(){
		craftSpeed = craftRigidbody.velocity.magnitude;
		craftAngSpeed = craftRigidbody.angularVelocity.magnitude;
		if(!gravityLatch){
			Vector3 gravity;
			gravity = Vector3.Normalize(gravityPos - craftTransform.position) * accleration;
			craftRigidbody.AddForce(gravity);
		}

		val= craftRigidbody.velocity.magnitude;
		val2= craftRigidbody.angularVelocity.magnitude;

		if(crash==true){
			ScoreScript.score = 0;
			if(Input.GetMouseButtonUp(0)){
				crashViewIndex ++;
				if(crashViewIndex>tempO.Length-1)
					crashViewIndex = 0;
			}
			craftTransform.gameObject.renderer.enabled=false;
			craftRigidbody.useGravity=false;
			craftRigidbody.velocity = Vector3.zero;

			if(gravityLatch==true)
				for(int i=0;i<tempO.Length;i++){
					Vector3 gravity;
					gravity = Vector3.Normalize(gravityPos - tempO[i].transform.position) * (accleration+1f);
					tempO[i].rigidbody.AddForce(gravity);
				}
		}
		else{
			if(StartButtonScript.status==-5){
				Vector3 tr;
				laser = GameObject.Instantiate(laserPrefab,laserPrefab.transform.position,craftTransform.rotation) as GameObject;
				tr = laser.transform.position;
				laser.transform.position = craftTransform.position;
				laser.transform.Translate(tr,Space.Self);
				laser.transform.Translate(0,-0.1f,0,Space.Self);
				laser.rigidbody.velocity = laser.transform.right*(craftRigidbody.rigidbody.velocity.magnitude+6f);
				laser.transform.parent = GameObject.Find("Level").transform;
				laser.name = "Laser";

				laser = GameObject.Instantiate(laserPrefab,laserPrefab.transform.position,craftTransform.rotation) as GameObject;
				tr = laser.transform.position;
				laser.transform.position = craftTransform.position;
				laser.transform.Translate(tr,Space.Self);
				laser.transform.Translate(0,0.1f,0,Space.Self);
				laser.rigidbody.velocity = laser.transform.right*(craftRigidbody.rigidbody.velocity.magnitude+6f);
				laser.transform.parent = GameObject.Find("Level").transform;
				laser.name = "Laser";
				StartButtonScript.status = 0;
			}
			if(StartButtonScript.status==-6){
				if(ShieldScript.numberOfForceFields>0){
					forceField = GameObject.Instantiate(forceFieldPrefab,craftTransform.transform.position,craftTransform.rotation) as GameObject;
					forceField.transform.parent = GameObject.Find("Level").transform;
					forceField.name = "ForceField";
					ShieldScript.numberOfForceFields--;
				}
				StartButtonScript.status = 0;
			}

			v= craftRigidbody.velocity;
			if(!levelDone){
				time += Time.deltaTime;
				ScoreScript.score -= Time.deltaTime*5.5f;
			}

		}


		if(StartButtonScript.status==-7){
			crash=false;
			craftTransform.gameObject.renderer.enabled=true;
			craftRigidbody.velocity = Vector3.zero;
			Collider[] c = craftTransform.gameObject.GetComponents<Collider>();
			c[0].enabled=true;
			c[1].enabled=true;
			levelLoader();
			levelDone = false;
			StartButtonScript.status = 0;
		}
		if(levelDone){
			craftRigidbody.velocity = Vector3.zero;
			craftRigidbody.angularVelocity = Vector3.zero;
		}
		if(StartButtonScript.status==-8){
			crash=false;
			craftTransform.gameObject.renderer.enabled=true;
			craftRigidbody.velocity = Vector3.zero;
			Collider[] c = craftTransform.gameObject.GetComponents<Collider>();
			c[0].enabled=true;
			c[1].enabled=true;
			StartButtonScript.status = 0;
			level++;
			if(level>18)
				level = 1;
			levelLoader();
			levelDone = false;
		}
	}//UpdateLevelPhysics method

	public void levelLoader(){
		levelReset ();
		if(level==1)
			loadLevel1();
		if(level==2)
			loadLevel2();
		if(level==3)
			loadLevel3();
		if(level==4)
			loadLevel4();
		if(level==5)
			loadLevel5();
		if(level==6)
			loadLevel6();
		if(level==7)
			loadLevel7();
		if(level==8)
			loadLevel8();
		if(level==9)
			loadLevel9();
		if(level==10)
			loadLevel10();
		if(level==11)
			loadLevel11();
		if(level==12)
			loadLevel12();
		if(level==13)
			loadLevel13();
		if(level==14)
			loadLevel14();
		if(level==15)
			loadLevel15();
		if(level==16)
			loadLevel16();
		if(level==17)
			loadLevel17();
		if(level==18)
			loadLevel18();
	}

	//angle, xPos, yPos, expForce, veloThres, angThres, grav, spang, spScalex, spScalex ,spxp, spyp, epang, epScalex, epScalex ,epxp, epyp
	void loadLevel1(){
		basicLevelSet(90,0,-6.25f,0,0.25f,1f,false,20,false,false,0);
	}
	void loadLevel2(){
		basicLevelSet(90,0,-14.25f,25,0.5f,1f,false,100,false,false,0);
	}
	void loadLevel3(){
		basicLevelSet(90,-5,-4.5f,25,0.5f,1f,false,100,false,false,0);
	}
	void loadLevel4(){
		basicLevelSet(90,0,-9.25f,25,0.5f,1f,false,100,false,false,0);	
	}
	void loadLevel5(){
		basicLevelSet(90,5.25f,-5.25f,25,0.5f,1f,false,100,false,true,1);	
	}
	void loadLevel6(){
		basicLevelSet(200,-1.5f,6.75f,25,0.5f,1f,false,100,false,false,0);	
	}
	void loadLevel7(){
		basicLevelSet(90,-6.25f,-3.75f,25,0.25f,1f,false,100,false,false,0);	
	}
	void loadLevel8(){
		basicLevelSet(90,0,-6.25f,0,0.5f,1f,false,50,true,false,0);
	}
	void loadLevel9(){
		basicLevelSet(90,10f,-29f,0,0.5f,1f,false,75,false,false,0);
	}
	void loadLevel10(){
		basicLevelSet(90,-5.5f,-11f,0,0.25f,1f,false,10,false,false,0);
	}
	void loadLevel11(){
		basicLevelSet(90,-10f,-2f,0,0.25f,1f,false,100,false,false,0);
	}
	void loadLevel12(){
		basicLevelSet(0,-10f,0f,0,0.25f,1f,false,100,true,true,1);
	}
	void loadLevel13(){
		basicLevelSet(90,0,-14.25f,25,0.5f,1f,false,100,false,true,1);
	}
	void loadLevel14(){
		basicLevelSet(180,6,-2.25f,25,0.5f,1f,false,100,true,true,1);
	}
	void loadLevel15(){
		basicLevelSet(180,1,12f,25,0.5f,1f,false,100,true,true,1);
	}
	void loadLevel16(){
		basicLevelSet(45,-0.533f,4.712f,25,0.5f,1f,false,100,true,true,1);
	}
	void loadLevel17(){
		basicLevelSet(90,-3.5f,1.52f,25,0.5f,1f,false,100,true,true,1);
	}
	void loadLevel18(){
		basicLevelSet(90,0,-14.25f,25,0.5f,1f,false,100,true,false,0);
	}

	void basicLevelSet(float angle,float xPos,float yPos, float expForce, float veloThres,float angThres,bool grav, float fuel,bool laserState, bool shieldState, int forceFielNumber){
		tempLevel = GameObject.Instantiate(levels[level-1],levels[level-1].transform.position,levels[level-1].transform.rotation) as GameObject;
		craftTransform.eulerAngles = new Vector3(0,0,angle);
		craftTransform.position = new Vector3(xPos,yPos,0);
		craftRigidbody.useGravity = grav;
		explosionForce=expForce;
		velocityThreshold=veloThres;
		angularVelocityThreshold = angThres;
		craft.craftFuel = fuel;

		crashed = false;
		crash = false;

		craft.counter = 0;
		craft.stabilizeVa = 0;

		Transform ch = tempLevel.transform.FindChild("Level");
		ch.name = "MeshLevel";
		if(ch!=null){
			ch.renderer.material.color = Color.black;
		}
		tempLevel.name = "Level";
		ScoreScript.state = true;
		ScoreScript.score = initialScores[level-1];
		LaserScript.state = laserState;
		ShieldScript.state = shieldState;
		ShieldScript.numberOfForceFields = forceFielNumber;
	}//BasicSet


	public void destroy(){
		GameObject.Destroy (tempLevel);
	}


	void levelReset(){
		time = 0f;
		destroy ();
		craftRigidbody.velocity = Vector3.zero;
		craftRigidbody.angularVelocity = Vector3.zero;	
		CraftScript.startFuel = false;
		next = false;
		LaserScript.state = false;
		ShieldScript.state = false;
	}

	public void endPadCollided(){
		if(!levelDone){
			preLevel = level;
			preTime = time;
			levelScore = (int)ScoreScript.score;

			if(CraftScript.stabilize){
					levelStarScore = 1;
			}
			else{
				if(levelScore<= twoStarScores[level-1])
					levelStarScore = 1;
				else if(levelScore<= threeStarScores[level-1])
					levelStarScore = 2;
				else if(levelScore<= initialScores[level-1] || levelScore>= initialScores[level-1] )
					levelStarScore = 3;
			}
			levelStarScoreLatch = levelStarScore;
			levelDone = true;
		}
	}
	public void collision(Collision other){
		if(crash==false){
			Vector3 vN = new Vector3();
			Vector3 vN2 = new Vector3();
			if(other.rigidbody!=null){
				vN = v-other.rigidbody.velocity;
				vN2 =other.rigidbody.angularVelocity;
			}
			else{
				vN = v-Vector3.zero;
				vN2 = Vector3.zero;
			}
			if(vN.magnitude>velocityThreshold|| vN2.magnitude>angularVelocityThreshold  || other.collider.name.Contains("Dead")){
				tempExplosion = GameObject.Instantiate(explosionObject, craftTransform.position,craftTransform.rotation) as GameObject;
				tempExplosion.transform.parent = GameObject.Find("Level").transform;

				Collider[] c = craftTransform.gameObject.GetComponents<Collider>();
				c[0].enabled=false;
				c[1].enabled=false;
				crash = true;
				Vector3 tr;
				
				Vector3 vel = craftRigidbody.velocity;  
				Vector3 rot = craftRigidbody.angularVelocity;  

				for(int i=0;i<brokenCraftObject.Length;i++){
					tempO[i] = GameObject.Instantiate(brokenCraftObject[i],brokenCraftObject[i].transform.position,craftTransform.rotation)as GameObject;
					tr = tempO[i].transform.position;
					tempO[i].transform.position = craftTransform.position;
					tempO[i].transform.Translate(tr,Space.Self);
					Rigidbody theR = tempO[i].rigidbody;
					theR.useGravity=gravityLatch;
					
					theR.velocity = vel;
					theR.angularVelocity = rot;
					if(tempO[i].name.Contains("Back1")){
						tempO[i].transform.eulerAngles+=new Vector3(0,0,45);
					}
					tempO[i].transform.parent = GameObject.Find("Level").transform;					
				} //break craft
				

			}//elseif in crash
			else{
				touching=true;
				touchString = other.collider.name;
			}//no crash
		}//if crash is false, has not happned yet
	}//collision method

	
}
