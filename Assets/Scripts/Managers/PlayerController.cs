using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private GameObject _player;
	private Transform  _playerTf;
	private CharacterComponent _playerCharacter;
	private bool _moveAllowed = true;

	GameManager.Turn _currentTurn = GameManager.Turn.PLAYER_TURN;
	private bool PlayerTurn { 
		get
		{
			if(_currentTurn == GameManager.Turn.PLAYER_TURN)
				return true;
			else 
				return false;
		}
	}
	
	private enum ContextAction{
		ATTACK,
		MOVE,
		NOTHING
	}
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		_player = GameObject.FindGameObjectWithTag(ObjTag.Player);
		_playerCharacter = _player.GetComponent<CharacterComponent>();
		_playerTf = _player.transform;
		EventManager.instance.publisher.subscribeTo("TurnPlayer",this, OnPlayerTurn);
		EventManager.instance.publisher.subscribeTo("TurnEnemy",this, OnEnemyTurn);
	}
	
	public void TriggerAction(Action action){
		//if(_currentTurn == GameManager.Turn.PLAYER_TURN)
			//action.Execute();
	}
	
	// Check if we collide with something. If it's an enemy or a wall, return its transform
	private Transform CheckCollision(Vector2 direction){
		RaycastHit2D[] hitArray = new RaycastHit2D[6];
		ContactFilter2D filter = new ContactFilter2D();
		
		int count = Physics2D.Raycast(_playerTf.position, direction, filter.NoFilter(), hitArray, 1.0f);
		if(count >= 1){
			foreach(RaycastHit2D hit in hitArray){
				if(hit.transform != null){
					//Debug.Log("Hit : " + hit.transform.tag);
					if(hit.transform.CompareTag(ObjTag.Enemy) || hit.transform.CompareTag(ObjTag.Wall)){
						return hit.transform;
					}
				}
			}
		}
		return null;
	}
	
	// Process movement input:
	// Check if it's the player turn
	// Check if direction is blocked
	// Choose ContextAction based on blocking tf tag
	// Decide what to do based on ContextAction
	public void OnMovementInput(Vector2 direction){
		if(!PlayerTurn || !_moveAllowed){
			return;
		}
		
		Transform blocked = CheckCollision(direction);
		ContextAction context = PickAction(blocked);
		if(context == ContextAction.MOVE){
			_moveAllowed = false;
			ActionController.instance.ExecuteAction(new MoveAction(_playerTf, direction));
		}
		else if(context == ContextAction.ATTACK){
			_moveAllowed = false;
			_playerCharacter.GetComponent<IAttack>().InitiateAttack(blocked);
		}
	}
	
	// Triggered at event player turn
	private void OnPlayerTurn(){
		_currentTurn = GameManager.Turn.PLAYER_TURN;
		_moveAllowed = true;
	}
	
	// Triggered at event enemy turn
	public void OnEnemyTurn(){
		_currentTurn = GameManager.Turn.ENEMY_TURN;
	}
		
	// Picks ContextAction based on the tag 
	private ContextAction PickAction(Transform tf){
		ContextAction context = new ContextAction();
		if(tf == null){
			return ContextAction.MOVE;
		}
		else if(tf.CompareTag(ObjTag.Enemy)){
			// Attack the enemy
			context = ContextAction.ATTACK;
			return context;
		}
		else if(tf.CompareTag(ObjTag.Wall)){
			context = ContextAction.NOTHING;
			return context;
		}
		else{
			context = ContextAction.MOVE;
			return context;
		}
	}
	
}
