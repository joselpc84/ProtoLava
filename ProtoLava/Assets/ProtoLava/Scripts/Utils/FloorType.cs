using UnityEngine;
using System.Collections;

public class FloorType : MonoBehaviour {

	public float groundDist = 0.0F;
	public LayerMask layer;
	public Transform objeto;
	public bool inGround = true;
	//public float rayDist

	// Use this for initialization
	void Start () {
	
		groundDist = transform.GetComponent<CapsuleCollider> ().bounds.extents.y;
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

		Debug.DrawRay(objeto.position, -Vector3.up * groundDist, Color.yellow);

		//Physics.Raycast(

		if (Physics.Raycast (objeto.position, -Vector3.up, out hitEstable,groundDist, layer)) {
			inGround = true;
			//Debug.Log ("TOCANDO PISO");
		} else {
			inGround = false;
			//Debug.DrawRay(objeto, -Vector3.up * 1000, Color.white);
			//Debug.Log ("EN EL AIRE");
		}
	}
}
