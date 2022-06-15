using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class ObjectPosition : MonoBehaviour
{
	[SerializeField]
	Vector2Int gridPos{get; set;}
	
	[SerializeField]
	bool isStatic, isBlocking;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Awake()
	{

	}
	
	public Vector2Int getGridPos(){
		return gridPos;
	}
	
	public void updateGridPosition(){
		gridPos = new Vector2Int((int)Mathf.Floor(transform.position.x - 0.5f), (int)Mathf.Floor(transform.position.y - 0.5f));
		LevelManager.instance.addBlockedCell(gridPos);
	}
	
	public void CenterObject(){
		Transform tf = gameObject.transform;
		
		// Disable collider to avoid weird artifacts when trying to center several objects
		GetComponent<BoxCollider2D>().enabled = false;
		double x = tf.position.x;
		double y = tf.position.y;
		
		double newx, newy;
		
		// Tile centers in the grid when it's at no + 0.5
		newx = Mathf.Floor((float)x) + 0.5;
		newy = Mathf.Floor((float)y) + 0.5;
		
		tf.position = new Vector3((float)newx, (float)newy, -1);
		GetComponent<BoxCollider2D>().enabled = true;
	}

	
}
