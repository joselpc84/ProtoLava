using UnityEngine;
using System.Collections;

public class FloorType : MonoBehaviour {

	public float groundDist = 0.0F;
	public LayerMask layerPisoEstable;
	public LayerMask layerPisoDinamico;
	public Transform objeto;
	public bool inGroundEstable = true;
	public bool inGroundDinamico = false;
	//public float rayDist

	// Use this for initialization
	void Start () {
	
		groundDist = transform.GetComponent<Collider> ().bounds.extents.y;
	}
	/*
	public bool IsGrounded(){
		return Physics.Raycast (transform.position, -Vector2.up, groundDist + 0.1);
	}
	*/

	// Update is called once per frame
	void Update () {
	
		//int layerMask = 1 << 8;

		RaycastHit hitEstable;
		RaycastHit hitDinamico;

		Debug.DrawRay(objeto.position, -Vector3.up * groundDist, Color.yellow);

		//Physics.Raycast(

		if (Physics.Raycast (objeto.position, -Vector3.up, out hitEstable,groundDist, layerPisoEstable)) {
			inGroundEstable = true;
			inGroundDinamico = false;
			//Debug.Log ("TOCANDO PISO");
		} else if(Physics.Raycast (objeto.position, -Vector3.up, out hitDinamico,groundDist, layerPisoDinamico)){
			inGroundEstable = false;
			inGroundDinamico = true;
			transform.SetParent(GameObject.Find("pisoMovil").transform);
			transform.position = Vector3.zero;
			transform.rotation = Quaternion.identity;

		}	
		else
		{
			inGroundEstable = false;
			//Debug.DrawRay(objeto, -Vector3.up * 1000, Color.white);
			//Debug.Log ("EN EL AIRE");
		}
	}
}
