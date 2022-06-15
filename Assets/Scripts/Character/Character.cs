using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void CenterChar(){
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
