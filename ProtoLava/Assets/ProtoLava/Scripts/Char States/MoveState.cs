using UnityEngine;
using System.Collections;

public class MoveState : FSMState {

	public float magnitudSalto = 50.0F;
	public float magnitudAlcanceX = 50.0F;
	public int LastJumpFrameCount = 0;
	public Vector3 vectorCameraReturn;

	//public Transform target;

	private Rigidbody subRigidBodyBegin;
	private InputController subOnBegin;
	public InputController input{
		
		get{
			if(subOnBegin == null){
				subOnBegin = GetComponent<InputController> ();
				
			}
			return subOnBegin;
		}
	}

	public Rigidbody rigidBody{
		
		get{
			if(subRigidBodyBegin == null){
				subRigidBodyBegin = GetComponent<Rigidbody> ();
				
			}
			return subRigidBodyBegin;
		}
	}
	
	protected override void Awake()
	{
		base.Awake();
		stateID = StateID.Move;
		
		
		AddTransition (Transition.MoveToDead, StateID.Dead);
		AddTransition (Transition.MoveToIdle, StateID.Idle);
		
		
	}
	
	public override void DoBeforeEntering(){
		input.onBegin += Preparar;
		input.onFinish += Saltar;
		
		
	}
	
	public override void DoBeforeLeaving(){
		input.onBegin -= Preparar;
		input.onFinish -= Saltar;
		
	}

	public void Preparar(){

	}

	public void Saltar(Vector2 movCursor){


		//GameObject.Find ("Main Camera").GetComponent<CameraScroll>().transform.position;

		vectorCameraReturn = (Vector3)GameObject.Find ("Main Camera").GetComponent<CameraScroll> ().cameraHistory [
		                             (GameObject.Find ("Main Camera").GetComponent<CameraScroll> ().cameraHistory.IndexOf (LastJumpFrameCount)) - 1];
		/*
		vectorCameraReturn.x *= -0.15F;
		vectorCameraReturn.y *= -0.2F;
		vectorCameraReturn.z *= -0.2F;
*/
	//FORZADO	//GameObject.Find ("Main Camera").transform.Translate (vectorCameraReturn * 0.2F);

		GameObject.Find ("Main Camera").transform.position = Vector3.Lerp(transform.position, vectorCameraReturn, 0.2F);
		/*
		GameObject.Find ("Main Camera").transform.position = 
			(Vector3)GameObject.Find ("Main Camera").GetComponent<CameraScroll>().cameraHistory[
			       (GameObject.Find ("Main Camera").GetComponent<CameraScroll> ().cameraHistory.IndexOf(LastJumpFrameCount)) - 1];
			       */

		LastJumpFrameCount = Time.frameCount;

		if (GameObject.Find ("Personaje").GetComponent<FloorType> ().inGroundEstable) {

			rigidBody.AddForce (Vector3.up * magnitudSalto);
			rigidBody.AddForce (Vector3.forward * magnitudAlcanceX);
			rigidBody.freezeRotation = true;
		
		} else {

			rigidBody.AddForce (Vector3.up * (magnitudSalto - 200));
			rigidBody.AddForce (Vector3.forward * magnitudAlcanceX);
			rigidBody.freezeRotation = true;
		}

		//Vector3 targetDir = target.position - transform.position.z + 10;
		//Vector3 forward = transform.forward.y + 3;
		//float angle = Vector3.Angle (targetDir, forward);
		//rigidBody.AddForce (Vector3.Angle (targetDir, forward));
		//rigidBody.AddForce (Vector3.

	}
}