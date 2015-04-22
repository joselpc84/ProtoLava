using UnityEngine;
using System.Collections;

public class MoveState : FSMState {

	public float magnitudSalto = 50.0F;
	public float magnitudAlcanceX = 50.0F;

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
		rigidBody.AddForce (Vector3.up * magnitudSalto);
		rigidBody.AddForce (Vector3.forward * magnitudAlcanceX);

		//Vector3 targetDir = target.position - transform.position.z + 10;
		//Vector3 forward = transform.forward.y + 3;
		//float angle = Vector3.Angle (targetDir, forward);
		//rigidBody.AddForce (Vector3.Angle (targetDir, forward));
		//rigidBody.AddForce (Vector3.

	}
}