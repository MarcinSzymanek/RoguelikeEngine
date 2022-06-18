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
	[SerializeField]
	public float offset_x;
	public float offset_y;
	private GridLayout grid;
	
	void Awake(){
		grid = GameObject.Find("Grid").GetComponent<Grid>();
		updateGridPosition();
	}
	
	public Vector2Int GetGridPos(){
		return gridPos;
	}
	
	public Vector2 GetCenterPos(){
		Transform tf = gameObject.transform;
		return new Vector2(tf.position.x + 0.5f + offset_x, tf.position.y + 0.5f + offset_y);
	}
	
	public void updateGridPosition(){
		Vector2Int oldPos = gridPos;
		gridPos = (Vector2Int)grid.WorldToCell(transform.position);
		LevelManager.instance.addBlockedCell(gridPos);
		LevelManager.instance.removeBlocked(oldPos);
	}
	
	public void CenterObject(){
		Transform tf = gameObject.transform;
		
		// Disable collider to avoid weird artifacts when trying to center several objects
		GetComponent<BoxCollider2D>().enabled = false;
		double x = tf.position.x;
		double y = tf.position.y;
		
		double newx, newy;
		
		// Tile centers in the grid when it's at no + 0.5 + offset
		newx = Mathf.Floor((float)x) + 0.5 + offset_x;
		newy = Mathf.Floor((float)y) + 0.5 + offset_y;
		
		tf.position = new Vector3((float)newx, (float)newy, -1);
		GetComponent<BoxCollider2D>().enabled = true;
	}

	
}
