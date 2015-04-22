using UnityEngine;
using System.Collections;

public class DeadState : FSMState {

	private InputController subOnBegin;
	public InputController input{
	
		get{
			if(subOnBegin == null){
				subOnBegin = GetComponent<InputController> ();

			}
			return subOnBegin;
		}
	}
	protected override void Awake()
	{
		base.Awake();
		stateID = StateID.Dead;


		AddTransition (Transition.DeadToMove, StateID.Move);
		AddTransition (Transition.DeadToIdle, StateID.Idle);

	
	}

	public override void DoBeforeEntering(){
	

	}

	public override void DoBeforeLeaving(){
	
	}

}
