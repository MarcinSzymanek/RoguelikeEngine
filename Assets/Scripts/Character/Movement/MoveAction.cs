using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
	public MoveAction(CharacterComponent char_, Vector2 dir){
		character = char_;
		direction = dir;
	}
	
	Vector2 direction;
	
	public override void Execute(){
		if(character.canMove){
			character.TryMove(direction);
		}		
	}
}
