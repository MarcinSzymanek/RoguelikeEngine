using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIManager : MonoBehaviour
{
	[SerializeField]
	List<IAIComponent> enemyList;
    
	void Awake(){
		enemyList = new List<IAIComponent>();
	}
	
	// Start is called before the first frame update
    void Start()
	{
		CharacterComponent[] chars = GameObject.Find("Characters").GetComponentsInChildren<CharacterComponent>();
		foreach(CharacterComponent enemy in chars){
			IAIComponent ai = enemy.GetAIComponent();
			if(ai != null){
				Debug.Log("Added ai component to ai manager");
				enemyList.Add(enemy.GetAIComponent());
			}
		}
		
		EventManager.instance.publisher.subscribeTo("TurnEnemy", this, ProcessEnemyTurn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void ProcessEnemyTurn(){
		foreach(IAIComponent enemy in enemyList){
			enemy.CalculateNextAction();
		}
		
		foreach(IAIComponent enemy in enemyList){
			enemy.ProcessQueuedAction();
		}
		GameManager.instance.NextTurn();
	}
}
