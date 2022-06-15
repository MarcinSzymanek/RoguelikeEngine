using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEdit : MonoBehaviour
{
	TileData tileData = new TileData();
	
	public bool addTileData(int ID){
		return tileData.addTileID(ID);
	}
	
	public void centerAllTiles(){
		foreach(Transform item in GameObject.Find("Level").transform)
		{
			item.gameObject.GetComponent<Tile>().CenterTile();
		}
	}
}
