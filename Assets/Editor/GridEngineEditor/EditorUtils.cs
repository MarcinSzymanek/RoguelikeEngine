using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// This script adds buttons and other GUI elements to the unity inspector.

[CustomEditor(typeof(Tile))]
public class EditorCenterTile : Editor
{
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		
		Tile script = (Tile)target;
		if(GUILayout.Button("Center Tile")){
			script.CenterTile();
		}
	}
}

[CustomEditor(typeof(ObjectPosition))]
public class EditorObjectPosition : Editor
{
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		
		ObjectPosition script = (ObjectPosition)target;
		if(GUILayout.Button("Center Object")){
			script.CenterObject();
		}
	}
}


[CustomEditor(typeof(TileEdit))]
public class ButtonCenterAllTiles : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		TileEdit levelEd = (TileEdit)target;
		
		if(GUILayout.Button("Center All Tiles")){
			levelEd.centerAllTiles();;
		}
	}
}

[CustomEditor(typeof(GridTools))]
public class ToggleGrid : Editor
{
	public override void OnInspectorGUI(){
		base.OnInspectorGUI();
		//DrawDefaultInspector();
		
		GridTools gridProp = (GridTools)target;
		GameObject gridOutline = gridProp.gameObject.transform.GetChild(0).gameObject;
		
		if(GUILayout.Button("Toggle grid")){
			if(!gridProp.showGrid){
				gridOutline.SetActive(true);
				gridProp.showGrid = true;
			}
			else{
				gridOutline.SetActive(false);
				gridProp.showGrid = false;
			}
		}
		
		if(GUILayout.Button("Remake grid")){
			gridProp.setupGrid(gridProp.width, gridProp.height, gridProp.startPosition);
		}
	}
}
