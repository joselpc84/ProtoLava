using UnityEngine;
using System.Collections;

public class IdleState : FSMState {
	
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
		stateID = StateID.Idle;
		
		
		AddTransition (Transition.IdleToDead, StateID.Dead);
		AddTransition (Transition.IdleToMove, StateID.Move);
		
		
	}
	
	public override void DoBeforeEntering(){
		input.onBegin += Preparar;

	}
	
	public override void DoBeforeLeaving(){
		input.onBegin -= Preparar;

	}
	
	public void Preparar(){
		fsm.PerformTransition (Transition.IdleToMove);
	}

}