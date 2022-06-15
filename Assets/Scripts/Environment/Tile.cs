using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tile : MonoBehaviour
{
	
	public int tileID = 0;
	static int MAX_TILES = 2000;
	public void Start(){
			
	}
	
	public void InitTile(){
		int ID = Random.Range(0, MAX_TILES);
		GameObject levelEd = GameObject.Find("LevelEditor");
		if(levelEd == null){
			Debug.Log("Couldn't find LevelEditor.");
			return;
		}
		
		bool IDaccepted = false;
		while(IDaccepted == false){
			if(levelEd.GetComponent<TileEdit>().addTileData(ID)){
				tileID = ID;
				IDaccepted = true;
			}
			else{
				if(ID + 1 == 2000){
					ID = Random.Range(0, MAX_TILES);
				}
				else{
					ID++;
				}
			}
		}
	}
	
	
	public void CenterTile(){
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



