using UnityEngine;
using System.Collections;

public class MovingFloors : MonoBehaviour {

	public Transform pisoMovil;

	public int size = 1;

	private Vector3 posicion;


	// Use this for initialization
	void Start () {
	
		posicion = transform.position;


		posicion.x = 0.0F;
		posicion.y = 0.2F;
		posicion.z = 2.0F;


		pisoMovil.Spawn(posicion, pisoMovil.rotation);


	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
