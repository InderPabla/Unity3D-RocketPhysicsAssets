using UnityEngine;
using System.Collections;

public class CraftScript {
	public static float rotateAccel = 0.25f;
	public static float velocityAccel = 1f;
	Rigidbody craftRigidbody;
	Transform craftTransform;

	public float craftFuel=100f;
	public static bool stabilize = true;
	public int counter = 0;
	public float stabilizeVa = 0f;

	public static float craftFuelStatic;

	float turnBoosterFuelLoss = 2.5f;
	float forwardBoosterFuelLoss = 4f;
	float stopBoosterFuelLoss = 8f;
	float detectorBoosterFuelLoss = 12.5f;

	public static bool startFuel = false;

	public CraftScript(Rigidbody r, Transform t) {
		craftRigidbody=r;
		craftTransform = t;

	}
	public void UpdateCraft () {

		if(LevelManager.crash){
			craftFuel-=stopBoosterFuelLoss*Time.deltaTime;
		}//crash
		else{
			if(ArrowTouchScript.status==0){
				counter ++;
				if(stabilize == true){
					if(counter >= 25){
						craftRigidbody.angularVelocity = new Vector3(0,0,stabilizeVa);
					}
				}
			}
			else if(ArrowTouchScript.status==1){
				if(!stabilize)
					craftFuel-=forwardBoosterFuelLoss*Time.deltaTime;
				if(stabilize)
					craftFuel-=(forwardBoosterFuelLoss/2f)*Time.deltaTime;
				MoveCraft();
			}
			else if(ArrowTouchScript.status==2){
				if(!stabilize)
					craftFuel-=turnBoosterFuelLoss*Time.deltaTime;
				if(stabilize)
					craftFuel-=(turnBoosterFuelLoss/2f)*Time.deltaTime;
				RotateCraftRight();
				stabilizeVa = -0.04f;
				counter = 0;

			}
			else if(ArrowTouchScript.status==3){
				if(!stabilize)
					craftFuel-=turnBoosterFuelLoss*Time.deltaTime;
				if(stabilize)
					craftFuel-=(turnBoosterFuelLoss/2f)*Time.deltaTime;
				RotateCraftLeft();
				stabilizeVa = 0.04f;
				counter = 0;

			}
			else if(ArrowTouchScript.status==4){
				if(!stabilize)
					craftFuel-=stopBoosterFuelLoss*Time.deltaTime;	
				if(stabilize)
					craftFuel-=(stopBoosterFuelLoss/2f)*Time.deltaTime;
				SlowCraft();
			}
		}//not crash

		if(!startFuel){
			if(craftFuel<=0)
				craftFuel=0;
			craftFuelStatic = craftFuel;
		}
		else{
			craftFuel = craftFuelStatic;
			if(craftFuel>100){
				craftFuel = 100;
				craftFuelStatic = 100;
			}
		}


		set2DBehaviours();



	}
	
	void RotateCraftLeft(){
		craftRigidbody.angularVelocity = new Vector3( 0,0,craftRigidbody.angularVelocity.z+rotateAccel*Time.deltaTime);	
	}
	
	void RotateCraftRight(){
		craftRigidbody.angularVelocity = new Vector3( 0,0,craftRigidbody.angularVelocity.z-rotateAccel*Time.deltaTime);	
	}
	void MoveCraft(){	
		Vector3 tempC = craftRigidbody.velocity;
		tempC.x+=Mathf.Cos(Mathf.Deg2Rad*(craftTransform.eulerAngles.z))*velocityAccel*Time.deltaTime;
		tempC.y+=Mathf.Sin(Mathf.Deg2Rad*(craftTransform.eulerAngles.z))*velocityAccel*Time.deltaTime;
		craftRigidbody.velocity=tempC;
		
	}
	
	void SlowCraft(){
		float radang = Mathf.Atan2(craftRigidbody.velocity.y, craftRigidbody.velocity.x);
		Vector3 tempC = craftRigidbody.velocity;
		tempC.x-=Mathf.Cos(radang)*velocityAccel*Time.deltaTime;
		tempC.y-=Mathf.Sin(radang)*velocityAccel*Time.deltaTime;
		craftRigidbody.velocity=tempC;
		
	}

	void set2DBehaviours(){
		Vector3 craftS = craftTransform.position;
		craftS.z =0;
		craftTransform.position = craftS;
		craftS = craftTransform.eulerAngles;
		craftS.x =0;
		craftS.y =0;
		craftTransform.eulerAngles = craftS;
	}


}
