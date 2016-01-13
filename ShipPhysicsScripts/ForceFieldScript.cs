using UnityEngine;
using System.Collections;

public class ForceFieldScript : MonoBehaviour {
	float timeOut = 3.0f;
	Transform craft;
	void Start () {
		Invoke ("DestroyNow", timeOut);
		StartCoroutine(FadeTo(0f, timeOut));
		craft = GameObject.Find("Craft").transform;

	}

	void Update () {
		transform.position = craft.position;
	}

	void DestroyNow (){
		DestroyObject (gameObject);
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
}
