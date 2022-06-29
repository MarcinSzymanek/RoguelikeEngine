using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMelee : Enemy
{
	[SerializeField]
	private AIEnemy _AI;
	[SerializeField]
	private CharacterComponent _charComp;
	[SerializeField]
	private Attributes _attributes;
	
	void Awake(){
		_AI = GetComponent<AIEnemy>();
		_charComp = GetComponent<CharacterComponent>();
	}
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
