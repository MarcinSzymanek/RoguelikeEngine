using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
	// This is a character, it must be interactable in some way and/or have Actions it can perform
	private ObjectPosition objPos;
	private new CharacterAudio audio;
	[SerializeField] private Attributes _attributes;
	[SerializeField] private UnitData charData;
	[SerializeField] private bool _canMove;

	public void SetMove(bool val){
		_canMove = val;
	}

	private bool _isPlayer;
	
	protected void Awake()
	{
		audio = GetComponent<CharacterAudio>();
		audio.SetAudio(audio.audioMovement, charData.GetSounds().onWalk);
		
		objPos = GetComponent<ObjectPosition>();
		_attributes = new Attributes();
		_attributes.InitAttributes(charData.defaultHp, charData.defaultAttack, charData.defaultArmour);
		
		GetComponent<Equipment>().equippedWeapon = charData.defaultWeapon;
		SetMove(true);
	}
	
	public Vector2Int GetPosition(){
		return objPos.GetGridPos();
	}
	
	public int OnAttacked(Transform source, int attack){
		int endHealth;
		Debug.Log(name + " attacked for " + attack.ToString());
		int finalDmg = _attributes.ApplyDamage(attack, out endHealth);
		Debug.Log(transform.name + " took " + finalDmg.ToString() + ". Current health: " + endHealth.ToString());
		if(endHealth < 1){
			OnZeroHp();
		}
		return endHealth;
		// Play damaged sfx, apply other effects, buffs/debuffs. Retaliation effects?
		// Log the attack in debug
	}
	
	private void OnZeroHp(){
		// Character dies... unless it has extra lives or ressurection, deathdoor gate etc
		Transform corpse = transform.Find("Corpse");
		corpse.SetParent(transform.parent);
		corpse.gameObject.SetActive(true);
		AudioSource sound = corpse.GetComponent<AudioSource>();
		sound.PlayOneShot(sound.clip);
		gameObject.SetActive(false);
	}
	
	public Attributes GetAttributes(){
		return _attributes;
	}
}
