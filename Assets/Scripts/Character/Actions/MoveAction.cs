using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action, IAction
{
	private string _logMsg;
	
	public string LogMsg{get => _logMsg;}
	
	public bool EndsTurn{get; set;}
	
	public MoveAction(Transform tf, Vector2 dir){
		_actorTf = tf;
		_direction = dir;
		MakeLogMessage();
	}
	
	Vector2 _direction;
	
	public void Execute(){
		_actorTf.GetComponent<Movement>().InitiateMove(_direction);
	}
	
	public void Undo(){
		_direction = -_direction;
		Execute();
	}
	
	private void MakeLogMessage(){
		_logMsg = _actorTf.name + " moves in direction " + _direction.ToString();
	}
}
