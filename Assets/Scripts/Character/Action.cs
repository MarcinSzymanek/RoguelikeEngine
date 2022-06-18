using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for any action
public abstract class Action
{
	public bool endsTurn{get; set;}
	protected CharacterComponent character;
	public abstract void Execute();
}
