using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTools : MonoBehaviour
{
	[SerializeField]
	public bool showGrid = false;
	[SerializeField]
	public int width, height;
	private SpriteRenderer spriteRenderer;
	[SerializeField]
	public Vector2Int startPosition;
	[SerializeField]
	private Vector3Int[] gridCells;
	private float offset_x, offset_y;
	
    
	public void setupGrid(int w, int h, Vector2Int start){
		spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
		width = w;
		height = h;
		offset_x = 0;
		offset_y = 0;
		if(w % 2 != 0){
			offset_x = 0.5f;
		}
		if(h % 2 != 0){
			offset_y = 0.5f;
		}
		startPosition = start;
		initializeGrid();
	}

	void initializeGrid(){
		
		int size = width*height;
		int index = 0;
		gridCells = new Vector3Int[size];
		
		for(int i = 0; i < width; i++){
			for(int j = 0; j < height; j++){
				gridCells[index] = new Vector3Int(i + startPosition.x, j + startPosition.y, 0);
				index++;
			}
		}
		
		spriteRenderer.size = new Vector2(width, height);
		spriteRenderer.gameObject.transform.position = new Vector3(startPosition.x - offset_x, startPosition.y - offset_y, 0);
	}
}
