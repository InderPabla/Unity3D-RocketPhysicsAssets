using UnityEngine;
using System.Collections;

public class DetectorScript : MonoBehaviour {
	float timeOut = 3.0f;
	bool detachChildren = false;
	
	void Start () {
		Color c = renderer.material.color;
		c.a= 1f;
		renderer.material.color = c;
		StartCoroutine(FadeTo(0f, timeOut));
	}

	void Awake ()
	{
		Invoke ("DestroyNow", timeOut);
		Invoke ("ColliderRemove", 2f);
		Invoke ("FadeOut", 1f);
	}

	void Update () {
		Vector3 eu = transform.eulerAngles;
		Vector3 v = rigidbody.velocity;
		Vector3 va = rigidbody.angularVelocity;
		eu.x=0;
		eu.y=0;
		v.z=0;
		va.x=0;
		va.y=0;
		transform.eulerAngles = eu;
		rigidbody.velocity = v;
		rigidbody.angularVelocity = va;


	}

	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = transform.renderer.material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			renderer.material.color = newColor;
			yield return null;
		}
	}

	void DestroyNow ()
	{

		if (detachChildren) {
			transform.DetachChildren ();
		}
		DestroyObject (gameObject);
	}
	void ColliderRemove ()
	{
		collider.enabled=false;
	}
	void FadeOut ()
	{
		ParticleEmitter ch = gameObject.GetComponentInChildren<ParticleEmitter>();
		ch.minEmission= 2;
		ch.maxEmission= 2;
	}
}
