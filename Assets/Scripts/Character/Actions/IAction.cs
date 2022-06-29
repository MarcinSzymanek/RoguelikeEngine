using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction 
{
	bool endsTurn{get; set;}
	string logMsg{get;}
	void Execute();
	void Undo();
}
