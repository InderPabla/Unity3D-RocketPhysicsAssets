using UnityEngine;
using System.Collections;

public class StartScreenAnimationScript : MonoBehaviour {
	public GameObject[] craftGroupsPrefab = new GameObject[4];

	void Start () {
		int ran = Random.Range(1,5);
		if(ran==5)
			ran = 4;
		GameObject craftGroups = Instantiate(craftGroupsPrefab[ran-1],craftGroupsPrefab[ran-1].transform.position,craftGroupsPrefab[ran-1].transform.rotation) as GameObject;

		craftGroups.transform.parent = GameObject.Find("StartScreen").transform;
	}

}
