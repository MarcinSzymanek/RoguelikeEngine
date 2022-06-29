using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridEngine;

public class ActionController : Singleton<ActionController>
{
	PlayerController _pc;
	
	void Start(){
		_pc = FindObjectOfType<PlayerController>();
	}
	
	public void OnTurnFinished(Transform actor){
		if (actor.CompareTag("Player")){
			GameManager.instance.NextTurn();
		}
	}
	
	public void ExecuteAction(IAction action){
		action.Execute();
	}
	
	private void RecordAction(Action action){
		// Record action
	}
	
	private void AddToLog(IAction Action){
		// Adds action to log
	}
}
