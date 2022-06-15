using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
	public TileData(){}
	private List<int> tileList = new List<int>();
	
	public bool addTileID(int ID){
			if(!tileList.Contains(ID)){
				tileList.Add(ID);
				return true;
			}
			else{
				return false;
			}
		}
}
