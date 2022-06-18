using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using GameState = GameManager.GameState;


public class InputManager : MonoBehaviour
{
	PlayerInput controls;
	InputActionMap gameplayActions;
	InputActionMap menuActions;
	InputActionMap inventoryActions;
	
	InputAction inputMove;
	
	MainGameInput m_gameInput;
	PauseInput m_pauseInput;
	InventoryInput m_inventoryInput;
	PlayerController playerController;
	CharacterComponent charComponent;
	
	GameState m_currentGameState;
	
	int subId;

	void Awake(){
		playerController = GetComponent<PlayerController>();
		GameObject player = GameObject.Find("Player");
		charComponent = player.GetComponent<CharacterComponent>();
		controls = GetComponent<PlayerInput>();
		gameplayActions = controls.actions.FindActionMap("Gameplay");
		inputMove = gameplayActions.FindAction("Move");		
	}

	void Start(){
		inputMove.performed += OnMove;
	}
	
	
	private void OnMove(InputAction.CallbackContext context){
		Debug.Log("Move key pressed");
		Debug.Log(context.ReadValueAsObject());
		Vector2 direction = (Vector2)context.ReadValueAsObject();
		
		// In manhattan controls diagonals are not permitted, so refuse input
		if(direction.x != 0 && direction.y != 0){
			return;
		}
		MoveAction moveAction = new MoveAction(charComponent, direction);
		playerController.triggerAction(moveAction);
	}
	
	void Update(){
	
	}
	
	
	
	void sampleFunc(){
		Debug.Log("Sample handler triggered");
	}
	
	public void processInput(){
		m_currentGameState = GameManager.instance.m_gameState;
		switch(m_currentGameState)
		{
		case GameState.MAIN:
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				MoveAction moveAction = new MoveAction(charComponent, new Vector2Int(0, 1));
				playerController.triggerAction(moveAction);
			}
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
		/*MovementFourDir m_movement;	
		
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
		}*/
	}
	
	private class PauseInput{
		
	}
	
	private class InventoryInput{
		
	}
	
	void MapControls(){
		
	}
	
	void SetupInputEvents(){
		//EventManager.instance.publisher.addEvent("")
	}
}
