using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abillity : MonoBehaviour 
{
	public abstract void Setup(string SFX);
	
	protected virtual void Finish(){
		if(endsTurn){
			ActionController.instance.OnTurnFinished(transform);
		}
	}
	
	protected string _SFXclipName {get; set;}
	protected PlayerController _playerController;
	protected float _animationSpeed;
	public bool endsTurn{get; set;}
}
