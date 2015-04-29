using UnityEngine;
using System.Collections;

public class LavaFloor : MonoBehaviour {

	public Transform pisoLava;
	public Vector3 posicion;
	
	public int size = 1;
	
	//private Vector3 posicion2;
	
	// Use this for initialization
	void Start () {
		
		//Transform pisoMovil2 = pisoMovil.
		posicion = transform.position;
		
		/*
		posicion.x = 0.0F;
		posicion.y = 0.2F;
		posicion.z = 2.0F;
*/
		/*
		posicion2.x = 1.0F;
		posicion2.y = 0.2F;
		posicion2.z = 2.0F;

		*/
		pisoLava.Spawn(posicion, pisoLava.rotation);
		
		//pisoMovil.Spawn (posicion2, pisoMovil.rotation);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
