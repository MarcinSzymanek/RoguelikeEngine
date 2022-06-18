using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	CharacterComponent playerCharacter;
	GameManager.Turn currentTurn = GameManager.Turn.PLAYER_TURN;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterComponent>();
		EventManager.instance.publisher.subscribeTo("TurnPlayer",this, OnPlayerTurn);
		EventManager.instance.publisher.subscribeTo("TurnEnemy",this, OnEnemyTurn);
	}
	
	public void triggerAction(Action action){
		if(currentTurn == GameManager.Turn.PLAYER_TURN)
			action.Execute();
	}
	
	public void OnPlayerTurn(){
		currentTurn = GameManager.Turn.PLAYER_TURN;
	}
	
	public void OnEnemyTurn(){
		currentTurn = GameManager.Turn.ENEMY_TURN;
	}
	
}
