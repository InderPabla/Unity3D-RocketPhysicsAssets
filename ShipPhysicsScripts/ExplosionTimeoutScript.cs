using UnityEngine;
using System.Collections;

public class ExplosionTimeoutScript : MonoBehaviour {
	float timeOut = 5.0f;
	bool detachChildren = false;
	public static bool finished = true;
	void Start () {
	
	}

	void Awake ()
	{
		ExplosionTimeoutScript.finished = false;
		Invoke ("FadeOut", timeOut/5f);
		Invoke ("DestroyNow", timeOut);
	}

	void FadeOut(){
		particleEmitter.maxSize*= .005f;
		particleEmitter.minSize*= .005f;
	}

	void DestroyNow ()
	{
		ExplosionTimeoutScript.finished = true;
		if (detachChildren) {
			transform.DetachChildren ();
		}
		DestroyObject (gameObject);
	}
}
