//
// StateIdTransition.cs
//
// Author:
//       Luis Alejandro Vieira <lavz24@gmail.com>
//
// Copyright (c) 2014 
//

/// <summary>
/// Place the labels for the Transitions in this enum.
/// Don't change the first label, NullTransition as FSMSystem class uses it.
/// </summary>
public enum Transition
{
	NullTransition, // Use this transition to represent a non-existing transition in your system
	MoveToDead,
	DeadToMove,
	MoveToIdle,
	IdleToMove,
	DeadToIdle,
	IdleToDead

}

/// <summary>
/// Place the labels for the States in this enum.
/// Don't change the first label, NullTransition as FSMSystem class uses it.
/// </summary>
public enum StateID
{
	NullStateID, // Use this ID to represent a non-existing State in your system
	Dead,
	Idle,
	Move
}