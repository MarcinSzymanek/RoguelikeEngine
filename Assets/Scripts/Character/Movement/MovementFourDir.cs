using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFourDir : MonoBehaviour
{
	ObjectPosition objPos;
    // Start is called before the first frame update
    void Start()
    {
	    objPos = GetComponent<ObjectPosition>();
    }
	
	public void startMove(Vector2Int dir){
		Vector2Int destination = objPos.getGridPos() + dir;
		// LevelManager keeps a list of blocked cells
		// Check if destination is blocked
		if(!LevelManager.instance.isBlocked(destination)){
			// Proceed move coroutine
			Debug.Log("Destination" + destination + " unblocked. Move allowed.");
		}
	}
}
