using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AIBaseStates;
using static AITypes;

// Base class for AI objects
// Necessary to use ScriptableObject to store AI component. All AI components should inherit from this class

[System.Serializable]
public abstract class AIBase
{
	protected AIType _type;
	protected ActivationState _state;
	protected Transform _tf;
	protected const ActivationState defaultState = ActivationState.INACTIVE;
}
