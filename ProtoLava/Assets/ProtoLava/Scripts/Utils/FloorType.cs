using UnityEngine;
using System.Collections;

public class FloorType : MonoBehaviour {

	public float groundDist = 0.0F;
	public LayerMask layerPisoEstable;
	public LayerMask layerPisoDinamico;
	public LayerMask layerPisoLava;
	public Transform objeto;
	public bool inGroundEstable = true;
	public bool inGroundDinamico = false;
	public bool inGroundLava = false;

	public bool showDebugs = true;
	//public float rayDist

	// Use this for initialization
	void Start () {
	
		//groundDist = transform.GetChild(0).GetComponent<CapsuleCollider> ().bounds.extents.y;
		groundDist = 1.01F;
	}
	/*
	public bool IsGrounded(){
		return Physics.Raycast (transform.position, -Vector2.up, groundDist + 0.1);
	}
	*/

	// Update is called once per frame
	void Update () {
	
		//objeto.position = GameObject.Find("PisoMovil(Clone)").transform.position;

		//Debug.Log (GameObject.Find("Plataforma").GetComponent<MovingFloors>().posicion);
		//Debug.Log (GameObject.Find("Plataforma").transform.GetChild(0).position);
	//ESTE	//Debug.Log (GameObject.Find("PisoMovil(Clone)").transform.position);
		//Debug.Log (GameObject.Find("PisoMovil(Clone)").GetComponent<MovingFloors>().posicion);
		//Debug.Log (GameObject.Find ("PisoMovil(Clone)").GetComponent<MovingFloors> ().pisoMovil.transform.position);
		//Debug.Log (GameObject.Find("Plataforma").GetComponentInChildren<

		//int layerMask = 1 << 8;

		RaycastHit hitEstable;
		RaycastHit hitDinamico;

		Debug.DrawRay(objeto.position, -Vector3.up * groundDist, Color.yellow);

		//Physics.Raycast(

		if (Physics.Raycast (objeto.position, -Vector3.up, out hitEstable,groundDist, layerPisoEstable)) {
			inGroundEstable = true;
			inGroundDinamico = false;
			inGroundLava = false;
			objeto.rotation = Quaternion.identity;

			if(showDebugs)
			{
				Debug.Log ("EN TIERRA FIRME");
			}
			//Debug.Log ("TOCANDO PISO");
		} else if(Physics.Raycast (objeto.position, -Vector3.up, out hitDinamico,groundDist, layerPisoDinamico)){
			inGroundEstable = false;
			inGroundDinamico = true;
			inGroundLava = false;
			Vector3 pos;
			//pos.x = GameObject.Find("PisoMovil(Clone)").transform.position.x;
			pos.x = GameObject.Find("PisoMovil(Clone)").transform.localPosition.x;
			pos.y = 1.2F;
			//pos.z = GameObject.Find("PisoMovil(Clone)").transform.position.z;
			pos.z = GameObject.Find("PisoMovil(Clone)").transform.localPosition.z;
			objeto.position = pos;
			objeto.rotation = Quaternion.identity;

			if(showDebugs)
			{
				Debug.Log ("EN PLATAFORMA");
			}

		} else if(Physics.Raycast (objeto.position, -Vector3.up, out hitDinamico,groundDist, layerPisoLava)){
			inGroundEstable = false;
			inGroundDinamico = false;
			inGroundLava = true;

			objeto.Translate (Vector3.down * Time.deltaTime);

			if(showDebugs)
			{
				Debug.Log("MUERTO");
			}

		}
		else
		{
			inGroundEstable = false;
			//Debug.DrawRay(objeto, -Vector3.up * 1000, Color.white);
			//Debug.Log ("EN EL AIRE");
		}
	}
	
}
