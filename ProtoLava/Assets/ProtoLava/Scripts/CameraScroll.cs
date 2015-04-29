using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour {

	public Vector3 direccion;
	public ArrayList cameraHistory;
	//public float[] posicionCamara;

	// Use this for initialization
	void Start () {
	
		cameraHistory = new ArrayList ();
		/*
		posicionCamara = new float[3];
		posicionCamara [0] = transform.position.x;
		posicionCamara [1] = transform.position.y;
		posicionCamara [2] = transform.position.z;
		*/
		cameraHistory.Add (transform.position);
		cameraHistory.Add (0);

		direccion.x = 0.15F;
		direccion.y = 0.2F;
		direccion.z = 0.2F;
	}
	
	// Update is called once per frame
	void Update () {
	
		//Debug.Log (transform.position);
		/*
		posicionCamara [0] = transform.position.x;
		posicionCamara [1] = transform.position.y;
		posicionCamara [2] = transform.position.z;
		*/
		cameraHistory.Add (transform.position);
		cameraHistory.Add (Time.frameCount);
		transform.Translate (direccion * Time.deltaTime);

	}
}
