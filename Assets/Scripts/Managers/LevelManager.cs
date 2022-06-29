using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : GridEngine.Singleton<LevelManager>
{
	[SerializeField]
	List<Vector2Int> blockedCellList = new List<Vector2Int>();
	
	public void addBlockedCell(Vector2Int pos){
		if(!blockedCellList.Contains(pos)){
			blockedCellList.Add(pos);
		}
		else{
			//Debug.Log("list already contains cell, do nothing");
		}
	}
	
	public void sortBlocked(){
		// TODO: Implement somesorta sorting algorithm
	}
	
	public bool isBlocked(Vector2Int pos){
		return(blockedCellList.Contains(pos));
	}
	
	public void removeBlocked(Vector2Int pos){
		if(blockedCellList.Contains(pos)){
			blockedCellList.Remove(pos);
		}
	}
	
	public void clearBlocked(){
		blockedCellList.Clear();
	}
}
	
