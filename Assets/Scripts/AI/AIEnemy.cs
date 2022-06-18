using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
	private enum AItype{
		MELEE,
		RANGED
	}
	
	public enum State{
		ACTIVE,
		INACTIVE
	}
	
	ObjectPosition playerPosition;
	ObjectPosition selfPosition;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void CalculateAction(){
		Debug.Log("Calculating action");
	}
	
	public void ProcessAction(){
		Debug.Log("Acting. Change turns after");
	}
	
	
}
