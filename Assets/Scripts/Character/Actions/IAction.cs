using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction 
{
	bool EndsTurn{get; set;}
	string LogMsg{get;}
	void Execute();
	void Undo();
}
