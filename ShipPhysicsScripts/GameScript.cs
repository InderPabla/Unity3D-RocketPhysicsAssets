using UnityEngine;
using System.IO;

public class GameScript : MonoBehaviour {
	public GameObject theCraftObject;
	GameObject craft;

	public GameObject mainCamera;
	GameObject tCamera;

	public GameObject startScreenObject;
	GameObject startScreen;

	public GameObject confirmPrefab;
	GameObject confirm;

	public GameObject controlsObject;
	GameObject controls;

	public GameObject levelSelectPrebaf;
	GameObject[] levelSelect; 

	public GameObject levelNumberPrebaf;
	GameObject[] levelNumber; 

	public GameObject nextPrefab;
	GameObject next;

	public GameObject modeChangePrefab;
	GameObject modeChange;

	bool started = false;
	float height;
	float width;

	private string filePath;

	Color c;

	int size;
	float[] normalModeScore;
	float[] hardModeScore;
	int[] star;
	ManagerScript managerScriptUse;

	bool resetMode = false;

	bool isNext = false;



	bool inStartScreen = false;
	void Start () {

		filePath = Application.persistentDataPath + "/ZedSpace_Spaceship_Settings.txt";
		size = 18;
		levelSelect = new GameObject[size/2];
		levelNumber = new GameObject[size/2];

		star = new int[size];


		for( int i=0;i<size;i++){
			star[i] = 0;
		}
		loadStartScreen();
	}

	void Update () {
		if(StartButtonScript.status == -1 && !started){
			if(File.Exists(filePath)){
				c = Color.yellow;
				
				string[] s = new string[size/**3*/];
				s = File.ReadAllLines(filePath);
				
				for(int i =0; i< size;i++){
					star[i] = int.Parse(s[i]);
				}
			}
			else{
				c = Color.magenta;
				string[] s = new string[size/**3*/];
				for(int i=0;i<s.Length;i++){
					s[i] = 0+""; 
				}
				File.WriteAllLines(filePath, s);
				
			}

			loadlevelScreen(false,0);
			StartButtonScript.status = 0;

		}
		else if(StartButtonScript.status == -2 || Input.GetKeyDown (KeyCode.Escape)){
			LevelManager.playing = false;
			if(!started && !resetMode  && inStartScreen){
				Application.Quit();
			}
			else if(!started && !resetMode  && !inStartScreen && !isNext){
				isNext = false;
				for(int i=0;i<size/2;i++){
					Destroy(levelSelect[i]);
					Destroy(levelNumber[i]);
				}
				Destroy(next);
				Destroy(modeChange);
				Destroy(tCamera);
				loadStartScreen();
			}
			else if((started && !resetMode) ){
				ManagerScript managerScript = craft.GetComponent<ManagerScript>();
				managerScript.levelManager.destroy();

				managerScript.destroy();
				Destroy(craft);
				Destroy(controls);
				loadStartScreen();
				loadlevelScreen(false,0);
				isNext = false;
				started= false;
			}
			else if(isNext){
				isNext = false;
				for(int i=0;i<size/2;i++){
					Destroy(levelSelect[i]);
					Destroy(levelNumber[i]);
				}
				Destroy(next);
				Destroy(modeChange);
				loadlevelScreen(false,0);
			}

			LaserScript.state = false;
			ShieldScript.state = false;
			ScoreScript.state = false;
			LevelManager.levelDone = false;
			StartButtonScript.status = 0;
		}
		else if(StartButtonScript.status == -3){
			if(!resetMode && !started){
				resetMode = true;
				enterConfirmScreen();
			}
			StartButtonScript.status = 0;
		}
		else if(StartButtonScript.status == -4){
			isNext = true;
			for(int i=0;i<size/2;i++){
				Destroy(levelSelect[i]);
				Destroy(levelNumber[i]);
			}
			Destroy(next);
			loadlevelScreen(true,size/2);
			StartButtonScript.status = 0;
		}
		else if(StartButtonScript.status >0 && !started && !resetMode){
			started = true;
			loadGame();
			managerScriptUse = craft.GetComponent<ManagerScript>();
			StartButtonScript.status = 0;


		}

		if (resetMode){
			if(ConfirmScript.confimed!=0){
				if(ConfirmScript.confimed==1){
					File.Delete(filePath);
					for( int i=0;i<size;i++){
						star[i] = 0;
					}
					exitConfirmScreen();
					resetMode = false;
				}
				if(ConfirmScript.confimed==2){
					exitConfirmScreen();
					resetMode = false;
				}
			}
		}//if resetMode
		if(started){
			if(managerScriptUse.levelManager!=null)
				if(LevelManager.levelStarScore>0){
					if(star[managerScriptUse.levelManager.preLevel-1]<LevelManager.levelStarScore){
						star[managerScriptUse.levelManager.preLevel-1] = LevelManager.levelStarScore;
					}
					LevelManager.levelStarScore = 0;

					string[] s = new string[size/**3*/];

					for(int i =0;i<s.Length;i++){
						s[i] = star[i]+"";
					}
				File.WriteAllLines(filePath,s);
				}
		}//if started


	}

	void enterConfirmScreen(){
		confirm = Instantiate(confirmPrefab, confirmPrefab.transform.position, confirmPrefab.transform.rotation) as GameObject;
	}

	void exitConfirmScreen(){
		Destroy(confirm);
	}

	void loadStartScreen(){
		this.tCamera = Instantiate(mainCamera) as GameObject;
		this.tCamera.transform.position = new Vector3(0,0,-10);
		Camera cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;

		startScreen = Instantiate(startScreenObject) as GameObject;
		startScreen.name = "StartScreen";
		inStartScreen = true;
	}
	void loadGame(){
		Destroy(modeChange);
		Destroy(tCamera);
		Destroy(startScreen);
		for(int i=0;i<size/2;i++){
			Destroy(levelSelect[i]);
			Destroy(levelNumber[i]);
		}
		Destroy(next);

		craft = Instantiate(theCraftObject, theCraftObject.transform.position, theCraftObject.transform.rotation) as GameObject;	
		LevelManager.staticLevel = StartButtonScript.status;
		inStartScreen = false;
	}

	void loadlevelScreen(bool n, int a){
		inStartScreen = false;
		if(!n){
			Destroy(startScreen);
			next =  Instantiate(nextPrefab, nextPrefab.transform.position, nextPrefab.transform.rotation) as GameObject;
			next.name = "Next";
			modeChange = Instantiate(modeChangePrefab,modeChangePrefab.transform.position,modeChangePrefab.transform.rotation) as GameObject;
		}
		float divisionY = (height-2f)/3f;
		float divisionX = (width-2f)/3f;
		float x=0;
		float y=height;
		for(int i = 0; i < size/2; i++){
			if(i%3==0){
				x = 0;
				y -= divisionY;
			}
			x += divisionX;
			levelSelect[i] = Instantiate(levelSelectPrebaf,levelSelectPrebaf.transform.position,levelSelectPrebaf.transform.rotation) as GameObject;
			levelSelect[i].transform.position = new Vector3(x,y,0);
			levelSelect[i].transform.position -= new Vector3(divisionX*2,divisionY*2,0);
			levelSelect[i].name = ""+(i+1+a);

			Transform[] childs = new Transform[4];

			for(int j=0 ;j<4; j++){
				childs[j] = levelSelect[i].transform.GetChild(j) ;
				childs[j].renderer.enabled = false;	
			}
			childs[star[i+a]].renderer.enabled = true;


			levelNumber[i] = Instantiate(levelNumberPrebaf,levelNumberPrebaf.transform.position,levelNumberPrebaf.transform.rotation) as GameObject;
			TextMesh text = levelNumber[i].transform.GetComponent<TextMesh>();
			levelNumber[i].transform.position = new Vector3(x,y,-1);
			levelNumber[i].transform.position -= new Vector3(divisionX*2,divisionY*2,0);
			levelNumber[i].name = "LevelNumber"+(i+1+a);
			text.text = (i+1+a)+"";
			text.renderer.material.color = c;
		}
	}
}
