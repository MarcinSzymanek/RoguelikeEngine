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
		playerController.OnMovementInput(direction);
	}
	
	private class MainGameInput{
	
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
