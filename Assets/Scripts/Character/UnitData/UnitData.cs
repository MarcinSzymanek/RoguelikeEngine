using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class UnitData : ScriptableObject
{
	public new string name;
	public string description;
	[SerializeField] private int _defaultHp;
	[SerializeField] private int _defaultAttack;
	[SerializeField] private int _defaultArmour;
	[SerializeField] private WeaponData _defaultWeapon;
	
	public int defaultHp{get => _defaultHp;}
	public int defaultAttack{get => _defaultAttack;}
	public int defaultArmour{get => _defaultArmour;}
	public WeaponData defaultWeapon{get => _defaultWeapon;}
	
	public Sprite spriteNormal;
	public Sprite spriteDead;
	
	[SerializeField]
	Sounds charSounds;
	
	[System.Serializable]
	public class Sounds{
		public AudioClip onDamage;
		public AudioClip onDeath;
		public AudioClip onWalk;
		public AudioClip onAttack;
	}
	
	public Sounds GetSounds(){
		return charSounds;
	}
	
}
