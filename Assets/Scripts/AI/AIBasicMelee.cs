using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AITypes;
using static AIBaseStates;

[System.Serializable]
public class AIBasicMelee : AIBase, IAIComponent
{
	private IAction _queuedAction;
	public AIBasicMelee(Transform tf)
	{
		_type = AIType.BASIC_MELEE;
		_state = defaultState;
		_tf = tf;
	}
	
	public IAction CalculateNextAction()
	{
		if(_state == AIBaseStates.ActivationState.INACTIVE)
		{
			_queuedAction = new MoveAction(_tf, new Vector2(-1, 0));
			return _queuedAction;
		}
		return null;
	}
	public
	void ProcessQueuedAction()
	{
		if(_queuedAction != null)
		{
			Debug.Log("queued action is not null!!");
			ActionController.instance.ExecuteAction(_queuedAction);
		}
	}
}
