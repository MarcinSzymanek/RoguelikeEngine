using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
	private int _health;
	private int _attack;
	private int _armour;
	public int health{get{return _health;}}
	public int armour{get{return _armour;}}
	public int attack{get{return _attack;}}
	
	public void InitAttributes(int hp, int att, int arm){
		_health = hp;
		_attack = att;
		_armour = arm;
	}
	
	public void TakeDamage(GameObject source, int damage){
		int finalDamage = damage - _armour;
		_health -= finalDamage;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
