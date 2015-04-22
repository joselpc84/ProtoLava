using UnityEngine;
using System.Collections;

public class MovingFloors : MonoBehaviour {

	public Transform pisoMovil;

	public int size = 1;

	public bool bordeIzq = false;
	public bool bordeDer = false;

	private Vector3 posicion;


	// Use this for initialization
	void Start () {
	
		posicion = transform.position;

		//posicion.x = 2;
		//posicion.y = 0.5F;
		//posicion.z = -9.9F;

		pisoMovil.Spawn(posicion, pisoMovil.rotation);


	}
	
	// Update is called once per frame
	void Update () {
	
		posicion.z += 1;
		/*
		if (!bordeDer && !bordeIzq) {
			posicion.z = transform.position.z + 0.1F;
		} else if (bordeIzq && !bordeDer) {
			posicion.z = transform.position.z + 0.1F;
		} else if (bordeDer && !bordeIzq) {
			posicion.z = transform.position.z - 0.1F;
		}

		if (transform.position.z >= 10) {
			bordeDer = true;
			bordeIzq = false;
		}
 
		if (transform.position.z <= -10) {
			bordeIzq = true;
			bordeDer = false;
		}
		*/

		transform.position = Vector3.Lerp (transform.position, posicion, 0.2F);

		//transform.Translate (posicion);
	}
}
