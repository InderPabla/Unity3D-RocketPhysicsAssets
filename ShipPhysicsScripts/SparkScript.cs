using UnityEngine;
using System.Collections;

public class SparkScript : MonoBehaviour {

	void Start () {
		Invoke ("DestroyNow", 0.4f);
	}

	void DestroyNow (){
		DestroyObject (gameObject);
	}
}
