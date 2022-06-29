using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Abillity
{
	const float SPEED = 2f;
	
	private CharacterAudio _charAudio;
	private ObjectPosition _objPos;
	private AudioSource _audioMove;
	private string _SFXfootsteps = "SFX_walking";
	
	private void Awake(){
		_playerController = FindObjectOfType<PlayerController>();
		_charAudio = GetComponent<CharacterAudio>();
		_objPos = GetComponent<ObjectPosition>();
		_animationSpeed = SPEED;
		_SFXclipName = _SFXfootsteps;
		endsTurn = true;
	}
	
	private void Start(){
		_audioMove = _charAudio.audioMovement;
	}
	
	public override void Setup(string SFXname){
		_SFXclipName = SFXname;
	}
	
	
	public void InitiateMove(Vector2 direction){
		_audioMove.PlayOneShot(_audioMove.clip);
		Vector3 v3dir = direction;
		StartCoroutine(MoveRoutine(v3dir));
	}
	
	private IEnumerator MoveRoutine(Vector3 direction){
		Vector3 position = transform.position;
		Vector3 destination = (transform.position + direction);
		//Debug.Log("Position = " + position + " Destinaton = " + destination);
		float distance = CalcDistance(position, destination);
		float prevDistance = distance;
		
		while(distance >= 0.01f){
			transform.Translate(direction * Time.deltaTime * _animationSpeed);
			distance = CalcDistance(transform.position, destination);
			if(prevDistance <= distance){
				distance = 0f;
				break;
			}
			prevDistance = distance;
			yield return null;
		}
		Finish();
	}
	
	protected override void Finish(){
		_objPos.updateGridPosition();
		_objPos.CenterObject();
	
		Debug.Log("MOVE COMPLETE");
		
		if(endsTurn){
			ActionController.instance.OnTurnFinished(transform);
		}
	}
	
	private float CalcDistance(Vector3 pos1, Vector3 pos2){
		float distX = Mathf.Abs(pos1.x - pos2.x);
		float distY = Mathf.Abs(pos1.y - pos2.y);
		return Mathf.Sqrt(Mathf.Pow(distX, 2) + Mathf.Pow(distY, 2));
	}
	
}
