using UnityEngine;
using System.Collections;

public class QuadTiles : MonoBehaviour {

	public Transform pisoNegro;
	public Transform pisoBlanco;

	public int row = 2;
	public int col = 2;

	public int size = 1;


	// Use this for initialization
	void Start () {
	
		Vector3 posicion = transform.position;
		bool isWhite = false;
		bool nextColor = false;

		for (int i=0; i<row; i++) {
			isWhite = !nextColor;
			nextColor = isWhite;
			posicion.z = transform.position.z + i * size;
			for (int j=0; j<col; j++) {
				posicion.x = transform.position.x + j * size ;
				if(isWhite)
				{
					pisoNegro.Spawn(posicion, pisoNegro.rotation);
					isWhite = false;
				}
				else
				{
					pisoBlanco.Spawn(posicion,pisoBlanco.rotation);
					isWhite = true;
				}
			}
			//posicion.z += i * size;
			posicion.x = transform.position.x;
			//pisoNegro.Spawn(posicion);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
