using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : Action, IAction
{
	Transform _target;
	int _attack;
	int _damage;
	bool _endsTurn;
	string _logMsg;
	
	public bool EndsTurn{get => _endsTurn; set=> _endsTurn = value;}
	public string LogMsg{get => _logMsg;}
	
	public AttackAction(Transform actor, Transform target, int attack){
		_actorTf = actor;
		_target = target;
		_attack = attack;
		SetLogMessage();
	}
	
	public void Execute(){
		// Actor attacks target	
		_damage = _target.GetComponent<CharacterComponent>().OnAttacked(_actorTf, _attack);
		Debug.Log(_logMsg);
	}
	
	public void Undo(){
		
	}
	
	private void SetLogMessage(){
		_logMsg = _actorTf.name + " attacks " + _target.name + " for " + _attack.ToString();
	}
}
