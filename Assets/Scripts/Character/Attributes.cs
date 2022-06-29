using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attributes
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
	
	public int ApplyDamage(int damage, out int health){
		int finalDamage = damage - _armour;
		_health -= finalDamage;
		Debug.Log("Health: " + _health.ToString() + " Dmg = " + finalDamage.ToString());
		health = _health;
		return finalDamage;
	}
}
