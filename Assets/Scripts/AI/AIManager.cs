using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
	[SerializeField]
	List<AIEnemy> enemyList;
    
	void Awake(){
		enemyList = new List<AIEnemy>();
	}
	
	// Start is called before the first frame update
    void Start()
	{
		AIEnemy[] chars = GameObject.Find("Characters").GetComponentsInChildren<AIEnemy>();
		foreach(AIEnemy enemy in chars){
			enemyList.Add(enemy);
		}
		
		EventManager.instance.publisher.subscribeTo("TurnEnemy", this, ProcessEnemyTurn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void ProcessEnemyTurn(){
		foreach(AIEnemy enemy in enemyList){
			enemy.CalculateAction();
		}
		
		foreach(AIEnemy enemy in enemyList){
			enemy.ProcessAction();
		}
		GameManager.instance.NextTurn();
	}
}
