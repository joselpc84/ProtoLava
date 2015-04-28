using UnityEngine;
using System.Collections;

public class FloorsAddMovement : MonoBehaviour {

	public Vector3 posicion;
	public bool bordeIzq = false;
	public bool bordeDer = false;
	public float speed = 0.1F;
	private GameObject tempCapsule;

	// Use this for initialization
	void Start () {
	
		posicion.x = transform.position.x;
		posicion.z = 2.0F;
		posicion.y = 0.2F;
	}
	
	// Update is called once per frame
	void Update () {
	
		//transform.position.z += 1;

		if (!bordeDer && !bordeIzq) {
			posicion.x = transform.position.x + speed;
		} else if (bordeIzq && !bordeDer) {
			posicion.x = transform.position.x + speed;
		} else if (bordeDer && !bordeIzq) {
			posicion.x = transform.position.x - speed;
		}

		if (transform.position.x >= 10) {
			bordeDer = true;
			bordeIzq = false;
		}
 
		if (transform.position.x <= -10) {
			bordeIzq = true;
			bordeDer = false;
		}


		transform.position = Vector3.Lerp (transform.position, posicion, 1.5F);
		/*
		if (GameObject.Find ("Personaje").GetComponent<FloorType> ().inGroundDinamico == true) {
			//tempCapsule = GameObject.Find ("Capsule"); 
			//tempCapsule.transform.position.Set(transform.position.x, tempCapsule.transform.position.y, transform.position.z);
			GameObject.Find ("Capsule").transform.position = transform.position;
		}
		*/

		//posicion.x += 0.1F;


		//transform.Translate (posicion);

	}
}
