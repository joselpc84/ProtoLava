using UnityEngine;
using System.Collections;

public class MeltingObjects : MonoBehaviour {

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (Vector3.down * Time.deltaTime);
		/*
		int count = 0;
		if (count <= 10) {
			//transform.position.y -= 2.0f;
			count++;
		}
		*/

	}
}
