using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Abillity, IAttack
{
	const float SPEED = 2f;
	CharacterComponent _char;
	WeaponData _usedWeapon;
	
	void Awake(){
		_playerController = FindObjectOfType<PlayerController>();
		_animationSpeed = SPEED;
		_char = GetComponent<CharacterComponent>();
		endsTurn = true;
	}
	
	void Start(){
		_usedWeapon = GetComponent<Equipment>().equippedWeapon;
	}
	
	public override void Setup(string SFXname){
		_SFXclipName = SFXname;
	}
	
	public void InitiateAttack(Transform target){
		// Calculate damage, call action in AC, apply debuffs, play animation etc etc
		int attack = CalculateAttack();
		AttackAction aa = new AttackAction(transform, target, attack);
		ActionController.instance.ExecuteAction(aa);
		CharacterAudio audio = GetComponent<CharacterAudio>();
		audio.SetAudio(audio.audioOther, _usedWeapon.sfx);
		audio.Play(audio.audioOther);
		Finish();
	}
	
	// Calculate attack value
	private int CalculateAttack(){
		Attributes attr = _char.GetAttributes();
		int weaponAttack = _usedWeapon.attackValue;
		int damage = attr.attack + weaponAttack;
		Debug.Log(name + " attacks for: " + damage);
		return damage;
	}
	
	
}
