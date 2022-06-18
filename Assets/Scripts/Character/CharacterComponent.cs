using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
	// This is a character, it must be interactable in some way and/or have Actions it can perform
	private ObjectPosition objPos;
	private Attributes attributes;
	
	[SerializeField] public bool canMove{get; set;}
	private float _speed = 2f;
	
	[SerializeField] List<Action> UnitActions;
	private bool isPlayer;
	
	public void SetSpeed(float amount){
		_speed = amount;
	}
	
	protected void Awake()
	{
		if(gameObject.tag == "Player"){
			isPlayer = true;
		}
		else{
			isPlayer = false;
		}
		
		objPos = GetComponent<ObjectPosition>();
		attributes = GetComponent<Attributes>();
		attributes.InitAttributes(40, 5, 0);
		canMove = true;
	}
	
	public Vector2Int GetPosition(){
		return objPos.GetGridPos();
	}
	
	// Checks whether a move is valid, before moving the character
	public void TryMove(Vector2 dir){
		canMove = false;
		Vector2Int destination = GetPosition() + Vector2Int.RoundToInt(dir);
		if(LevelManager.instance.isBlocked(destination)){
			Debug.Log("Something is blocking the path!");
			canMove = true;
			return;
		}
		
		
		Debug.Log("Initiating move");
		Vector3 realDir = dir;
		InitiateMove(dir);
	}
	
	private void InitiateMove(Vector3 dir){
		StartCoroutine(MoveRoutine(dir));
	}
	
	IEnumerator MoveRoutine(Vector3 direction){
		Vector3 position = transform.position;
		Vector3 destination = (transform.position + direction);
		Debug.Log("Position = " + position + " Destinaton = " + destination);
		float distance = CalcDistance(position, destination);
		float prevDistance = distance;
		AudioManager.instance.AddAudio(this.gameObject, "SFX_walking");
		while(distance >= 0.01f){
			transform.Translate(direction * Time.deltaTime * _speed);
			distance = CalcDistance(transform.position, destination);
			if(prevDistance <= distance){
				distance = 0f;
			}
			prevDistance = distance;
			yield return null;
		}
		
		objPos.updateGridPosition();
		objPos.CenterObject();
		AudioManager.instance.RemoveAudio(this.gameObject, "SFX_walking");
		Debug.Log("MOVE COMPLETE");
		if(isPlayer){
			GameManager.instance.NextTurn();
		}
		canMove = true;
	}
	
	private float CalcDistance(Vector3 pos1, Vector3 pos2){
		float distX = Mathf.Abs(pos1.x - pos2.x);
		float distY = Mathf.Abs(pos1.y - pos2.y);
		return Mathf.Sqrt(Mathf.Pow(distX, 2) + Mathf.Pow(distY, 2));
	}
	
	
}
