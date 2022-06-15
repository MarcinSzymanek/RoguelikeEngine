using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameState = GameManager.GameState;


public class InputManager : MonoBehaviour
{
	MainGameInput m_gameInput;
	PauseInput m_pauseInput;
	InventoryInput m_inventoryInput;
	
	int subId;

	void Start(){
		EventManager.instance.publisher.addEvent("KeyPressEvent");
		EventManager.instance.publisher.subscribeTo("KeyPressEvent",this, sampleFunc );
	}
	
	void Update(){
		if(Input.anyKeyDown){
			Debug.Log("A key has been pressed");
		}
		if(Input.GetKeyDown(KeyCode.Mouse1)){
			EventManager.instance.publisher.raiseEvent("KeyPressEvent");
		}
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			EventManager.instance.publisher.addEvent("KeyPressEvent");
			EventManager.instance.publisher.subscribeTo("KeyPressEvent",this, sampleFunc );
		}
	}
	
	GameState m_currentGameState;
	
	public enum InputKey{
		INP_UP,
		INP_DOWN,
		INP_LEFT,
		INP_RIGHT
	}
	
	void sampleFunc(){
		Debug.Log("Sample handler triggered");
	}
	
	public void processInput(GameState g_state, InputKey i_key){
		m_currentGameState = g_state;
		switch(g_state)
		{
		case GameState.MAIN:
			m_gameInput.processInput(i_key);
			break;
		case GameState.INVENTORY:
			// TODO inventory input
			break;
		case GameState.PAUSE:
			// TODO pause input
			break;
		}
	}
	
	
	private class MainGameInput{
		MovementFourDir m_movement;	
		
		public void processInput(InputKey i_key){
			switch(i_key)
			{
			case InputKey.INP_UP:
				m_movement.startMove(new Vector2Int(0, 1));
				break;
			case InputKey.INP_DOWN:
				m_movement.startMove(new Vector2Int(0, -1));
				break;
			case InputKey.INP_RIGHT:
				m_movement.startMove(new Vector2Int(1,  0));
				break;
			case InputKey.INP_LEFT:
				m_movement.startMove(new Vector2Int(-1,  0));
				break;
			}
		}
	}
	
	private class PauseInput{
		
	}
	
	private class InventoryInput{
		
	}
}
