using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : GridEngine.Singleton<GameManager>
{
	TurnManager m_turnManager;
	InputManager m_inputManager;
	GameState m_gameState;
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
	
    // Start is called before the first frame update
    void Start()
	{
		m_inputManager = GetComponent<InputManager>();
		m_turnManager = new TurnManager();
		m_turnManager.initTurnManager();
		//event_input.AddListener(sendInput);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	void sendInput(InputManager.InputKey i_key){
		m_inputManager.processInput(m_gameState, i_key);
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
		
		public void endPlayerTurn(){
			// Display "Enemy turn"
			// Progress buffs/debuffs/effects
			// Perhaps calculate enemy turn order
			// Calculate enemy AI movement/actions
			// Progress enemy actions
			// at the end call event_enemyEndTurn
			currentTurn = Turn.ENEMY_TURN;
			turnCount++;
		}
	
	}
}
