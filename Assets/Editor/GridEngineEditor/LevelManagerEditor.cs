using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor
{
	// Called every time the inspector is drawn in Unity
	public override void OnInspectorGUI()
	{
		LevelManager myManager = (LevelManager)target;
	}
}
