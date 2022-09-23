using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAIComponent 
{
	IAction CalculateNextAction();
	void ProcessQueuedAction();
}
