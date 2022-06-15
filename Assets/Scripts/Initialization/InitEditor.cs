using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class SendTileIDs
{
	static bool ProjectLoaded = false;
	static SendTileIDs(){
		if(ProjectLoaded){
			return;
			
		}
		//he
		ProjectLoaded = true;
		Debug.Log("Project Loaded");
		Transform blocked = GameObject.Find("Grid").transform.Find("Walls");
		GameObject characters = GameObject.Find("Characters");
		if(blocked == null){
			return;
		}
		int i = 0;
		
		foreach(Transform item in blocked){
			i++;
			item.GetComponent<Tile>().InitTile();
			
			// If object has ObjectPosition component, add update its grid position
			if(item.TryGetComponent(out ObjectPosition op)){
				Debug.Log("Trying get comp : ");
				Debug.Log(i);
				op.updateGridPosition();
			}
		}
		
		foreach(Transform item in characters.transform){
			if(item.TryGetComponent(out ObjectPosition op)){
				op.updateGridPosition();
			}
		}
		LevelManager.instance.sortBlocked();
		
		Debug.Log("Tiles ready");
	}
}



