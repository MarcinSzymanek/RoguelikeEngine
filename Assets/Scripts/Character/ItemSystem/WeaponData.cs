using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
	public new string name;
	public string description;
	[SerializeField] int _attackValue;
	[SerializeField] int _armorPiercing;
	public Sprite sprite;
	public AudioClip sfx;
	
	public int attackValue{get => _attackValue;}
	public int armorPiercing{get => _armorPiercing;}
}
