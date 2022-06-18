using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : GridEngine.Singleton<GameManager>
{
	TurnManager m_turnManager;
	InputManager m_inputManager;
	public GameState m_gameState;
	bool blockActionInput;
	UnityEvent event_input;
	
	public enum GameState{
		MAIN,
		INVENTORY,
		PAUSE
	}
	
	public enum Turn{
		PLAYER_TURN,
		ENEMY_TURN
	}
	
	void OnEnable(){
		EventManager.instance.publisher.addEvent("TurnPlayer");
		EventManager.instance.publisher.addEvent("TurnEnemy");
	}
	
	void Start(){
		m_inputManager = GetComponent<InputManager>();
		m_turnManager = new TurnManager();
		m_turnManager.initTurnManager();
	}
	
	public void NextTurn(){
		m_turnManager.NextTurn();
	}
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
	private class TurnManager
	{
		private int turnCount;

		private Turn currentTurn;
	
		UnityEvent event_playerEndTurn;
		UnityEvent event_enemyEndTurn;
		
		public void initTurnManager(){
			turnCount = 0;
		}
		
		public void NextTurn(){
			// Display "Enemy turn"
			// Progress buffs/debuffs/effects
			// Perhaps calculate enemy turn order
			// Calculate enemy AI movement/actions
			// Progress enemy actions
			// at the end call event_enemyEndTurn
			if(currentTurn == Turn.ENEMY_TURN){
				currentTurn = Turn.PLAYER_TURN;
				Debug.Log("Player Turn");
				EventManager.instance.publisher.raiseEvent("TurnPlayer");
			}
			else{
				currentTurn = Turn.ENEMY_TURN;
				Debug.Log("Enemy Turn");
				EventManager.instance.publisher.raiseEvent("TurnEnemy");
			}
			turnCount++;
		}
		
	
	
	}
}
